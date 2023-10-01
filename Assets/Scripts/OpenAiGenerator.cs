using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using OpenAI;
using OpenAI.Chat;
using UnityEngine;

// public record DinosaurDescription(string Name, string Motto);

public class OpenAiGenerator
{
    private OpenAIClient openAIClient;

    OpenAiGenerator()
    {
        openAIClient = new OpenAIClient(OpenAIAuthentication.Default.LoadFromEnvironment());
    }

    // public static DinosaurDescription generateDinosaurDescription(List<string> foods)
    // {
    //     var messages = new List<Message>
    //     {
    //         new Message(Role.System, "You are a helpful assistant."),
    //         new Message(Role.User, "Wymyśl nazwę i motto dla dinozaura lubiącego {}."),
    //     };
    // }
}
