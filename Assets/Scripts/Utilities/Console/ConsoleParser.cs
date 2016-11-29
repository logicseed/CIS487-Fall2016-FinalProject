// Marc King - mjking@umich.edu

using System;
using System.Collections.Generic;
using UnityEngine;



public partial class ConsoleParser
{
    public delegate void CommandHandler(string[] args);

    public delegate void OutputChangedHandler(string[] output);
    public event OutputChangedHandler outputChanged;

    public delegate void VisibilityChangedHandler(bool visible);
    public event VisibilityChangedHandler visibilityChanged;

    private Queue<string> outputHistory;
    private int outputHistorySize;

    private Dictionary<string, CommandMapper> commands;
    private List<string> commandHistory;

    public ConsoleParser(int outputHistorySize)
    {
        outputHistory = new Queue<string>();
        this.outputHistorySize = outputHistorySize;
        
        commands = new Dictionary<string, CommandMapper>();
        commandHistory = new List<string>();
        MapCommands();
    }

    public void AppendOutput(string entry)
    {
        if (outputHistory.Count >= outputHistorySize)
        {
            outputHistory.Dequeue();
        }
        outputHistory.Enqueue(entry);

        outputChanged(outputHistory.ToArray());
    }

    private string[] ParseCommand(string command)
    {
        // Tokens used by Split
        char[] spaceToken = { ' ' };
        char[] quoteToken = { '"' };

        // Break into quoted and non-quoted sections
        // We can't ignore blanks because we may have two quoted sections in a row
        var sections = command.Split(quoteToken, StringSplitOptions.None);

        // Since every command should begin with unquoted string, every even index is unquoted.
        var commandElements = new List<string>();

        for (int i = 0; i < sections.Length; i++)
        {
            if (sections[i] == "") continue;

            // Split even elements by spaces
            if (i.IsEven() && sections[i] != "")
            {
                var subSections = sections[i].Split(spaceToken, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < subSections.Length; j++)
                {
                    if (i == 0 && j == 0)
                        // Make sure the base command is lowercase
                        commandElements.Add(subSections[j].ToLower());
                    else
                        commandElements.Add(subSections[j]);
                }
            }
            else // Odd elements are quoted, so we just add them.
            {
                commandElements.Add(sections[i]);
            }
        }

        return commandElements.ToArray();
    }

    public void ProcessCommand(string command)
    {
        // potential command start characters
        // ֎ ߦ ᐅ ‡ • → ⇒ ∷ 〉 ⏵ ⏹ ⏺ █ ► ◆ ◇ ▶ ◉ ◙ ◎ ● ◯ ☈ ⛋ ⛒ ⛚ ✚ ✱ ➜ ➲ ⮩ ⮡ ⯀ ⯁ ⯃ ⯄ ⯈ ꔪ 
        AppendOutput(("➜ " + command).RichTextColor(ConsoleMaterialColor.DeepOrange).RichTextBold());
        commandHistory.Add(command);

        var commandElements = ParseCommand(command);

        if (commandElements.Length < 1)
        {
            Debug.LogError("Cannot process console command '" + command + "'");
            return;
        }

        var parameters = new string[0];

        if (commandElements.Length > 1)
        {
            var parameterCount = commandElements.Length - 1;
            parameters = new string[parameterCount];
            Array.Copy(commandElements, 1, parameters, 0, parameterCount);
        }

        ExecuteCommand(commandElements[0], parameters);
    }

    private void ExecuteCommand(string command, string[] parameters)
    {
        if (!commands.ContainsKey(command))
        {
            Debug.LogError("Unknown console command '" + command + "', type 'help' for a command list.");
            return;
        }

        if (commands[command] == null)
        {
            Debug.LogException(new NullReferenceException("Console command '" + command + "' has a null handler."));
            return;
        }

        commands[command].Handler(parameters);
    }

    private void MapCommand(string command, CommandHandler handler, string help)
    {
        commands.Add(command, new CommandMapper(command, handler, help));
    }

    private class CommandMapper
    {
        /// <summary>
        /// 
        /// </summary>
        public string Command { get { return command; } }
        private string command;

        /// <summary>
        /// 
        /// </summary>
        public CommandHandler Handler { get { return handler; } }
        private CommandHandler handler;

        /// <summary>
        /// 
        /// </summary>
        public string Help { get { return help; } }
        private string help;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <param name="help"></param>
        public CommandMapper(string command, CommandHandler handler, string help)
        {
            this.command = command;
            this.handler = handler;
            this.help = help;
        }
    }

    public string[] OutputHistory
    {
        get
        {
            return outputHistory.ToArray();
        }
    }

}
