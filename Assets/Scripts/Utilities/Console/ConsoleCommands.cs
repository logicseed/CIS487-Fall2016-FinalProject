// Marc King - mjking@umich.edu

using System;
using System.Text;

using UnityEngine;
using UnityEngine.SceneManagement;


public partial class ConsoleParser
{
    /*
     * Instructions
     * 
     * 
     * 
     */
    private void MapCommands()
    {
        //When adding commands, you must add a call below to registerCommand() with its name, implementation method, and help text.
        MapCommand("zoom", zoom, "Sets the camera zoom. Syntax: zoom [zoom level].");
        MapCommand("babble", babble, "Example command that demonstrates how to parse arguments. babble [word] [# of times to repeat]");
        MapCommand("echo", echo, "echoes arguments back as array (for testing argument parser)");
        MapCommand("help", help, "Print this help.");
        MapCommand("hide", hide, "Hide the console.");
        MapCommand("reload", reload, "Reload game.");
        MapCommand("resetprefs", resetPrefs, "Reset & saves PlayerPrefs.");
    }

    #region Command handlers
    //Implement new commands in this region of the file.

    void zoom(string[] args)
    {

        var cameraController = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraController>();
        Debug.Log("Found camera controller: current zoom = " + cameraController.ZoomLevel);
        cameraController.ZoomLevel = Convert.ToSingle(args[0]);
    }

    /// <summary>
    /// A test command to demonstrate argument checking/parsing.
    /// Will repeat the given word a specified number of times.
    /// </summary>
    void babble(string[] args)
    {
        if (args.Length < 2)
        {
            AppendOutput("Expected 2 arguments.");
            return;
        }
        string text = args[0];
        if (string.IsNullOrEmpty(text))
        {
            AppendOutput("Expected arg1 to be text.");
        }
        else
        {
            int repeat = 0;
            if (!Int32.TryParse(args[1], out repeat))
            {
                AppendOutput("Expected an integer for arg2.");
            }
            else
            {
                for (int i = 0; i < repeat; ++i)
                {
                    AppendOutput(string.Format("{0} {1}", text, i));
                }
            }
        }
    }

    void echo(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string arg in args)
        {
            sb.AppendFormat("{0},", arg);
        }
        sb.Remove(sb.Length - 1, 1);
        AppendOutput(sb.ToString());
    }

    void help(string[] args)
    {
        foreach (CommandMapper reg in commands.Values)
        {
            AppendOutput(string.Format("{0}: {1}", reg.Command.RichTextColor(MaterialColor.Cyan), reg.Help));
        }
    }

    void hide(string[] args)
    {
        if (visibilityChanged != null)
        {
            visibilityChanged(false);
        }
    }

    void reload(string[] args)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void resetPrefs(string[] args)
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    #endregion
}
