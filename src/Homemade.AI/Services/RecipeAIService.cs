using Grpc.Core;

using Microsoft.Extensions.AI;

using AIChatMessage = Microsoft.Extensions.AI.ChatMessage;

namespace Homemade.AI.Services;

/// <summary>
/// gRPC service implementation for Recipe AI operations using Microsoft.Extensions.AI.
/// </summary>
public sealed class RecipeAIService(
    ILogger<RecipeAIService> logger,
    IChatClient chatClient
) : RecipeAI.RecipeAIBase
{
    public override async Task Chat(ChatRequest request, IServerStreamWriter<ChatResponse> responseStream, ServerCallContext context)
    {
        logger.LogInformation("Starting chat conversation");

        var messages = new List<AIChatMessage>
        {
            new(ChatRole.System, GetChatSystemPrompt(request.Context))
        };

        // Add conversation history
        foreach (var historyMessage in request.History)
        {
            var role = historyMessage.Role.ToLowerInvariant() switch
            {
                "user" => ChatRole.User,
                "assistant" => ChatRole.Assistant,
                _ => ChatRole.User
            };
            messages.Add(new(role, historyMessage.Content));
        }

        // Add current user message
        messages.Add(new(ChatRole.User, request.Message));

        var options = new ChatOptions
        {
            AllowMultipleToolCalls = true,
            Tools = [new HostedWebSearchTool()]
        };

        // Stream the response
        await foreach (var update in chatClient.GetStreamingResponseAsync(messages, options: options, cancellationToken: context.CancellationToken))
        {
            if (!string.IsNullOrEmpty(update.Text))
            {
                await responseStream.WriteAsync(new ChatResponse
                {
                    Content = update.Text,
                    IsComplete = false
                }, context.CancellationToken);
            }
        }

        // Send completion marker
        await responseStream.WriteAsync(new ChatResponse
        {
            Content = string.Empty,
            IsComplete = true
        }, context.CancellationToken);

        logger.LogInformation("Chat conversation completed");
    }

    private static string GetChatSystemPrompt(string? context)
    {
        var basePrompt = """
            You are a helpful cooking and recipe assistant. You can answer questions about:
            - Cooking techniques and methods
            - Recipe suggestions and modifications
            - Ingredient substitutions
            - Meal planning
            - Kitchen equipment
            - Food storage and safety
            - Dietary considerations

            Be friendly, concise, and practical in your responses.
            """;

        if (!string.IsNullOrWhiteSpace(context))
        {
            basePrompt += $"\n\nCurrent context: {context}";
        }

        return basePrompt;
    }
}
