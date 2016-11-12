// Marc King - mjking@umich.edu

using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls interactions between the console parser and the UI elements.
/// </summary>
[DisallowMultipleComponent]
public class ConsoleController : MonoBehaviour
{
    #region Inspector Fields
    
    [Header("UI Reference Settings")]   

    [SerializeField]
    [Tooltip("The UI->Image GameObject that displays the background and contains the InputField, Text, and Scrollbar for the console as children.")]
    private Image background;

    [SerializeField]
    [Tooltip("The UI->InputField GameObject that will receive console input.")]
    private InputField input;

    [SerializeField]
    [Tooltip("The UI->Text GameObject that will display the console output.")]
    private Text output;

    [SerializeField]
    [Tooltip("The UI->Scrollbar GameObject that will scroll the output.")]
    private Scrollbar scrollbar;

    [Header("Console Settings")]

    [SerializeField]
    [Tooltip("The maximum number of entries maintained by the console output.")]
    [Range(20,1000)]
    private int outputHistorySize = 20;

    #endregion Inspector Fields

    #region External References

    private ConsoleParser parser;

    private Animator animator;

    #endregion External References

    #region MonoBehaviour Methods

    /// <summary>
    /// Initializes any required objects.
    /// </summary>
    private void Awake()
    {
        if (parser == null)
        {
            parser = new ConsoleParser(outputHistorySize);
        }

        if (animator == null)
        {
            animator = background.gameObject.GetComponent<Animator>();
            animator.enabled = false;
        }
    }

    /// <summary>
    /// Subscribes to console events.
    /// </summary>
    private void Start()
    {
        if (parser != null)
        {
            parser.visibilityChanged += OnVisibilityChanged;
            parser.outputChanged += OnOutputChanged;
        }

        WelcomeMessage();
    }

    /// <summary>
    /// Unsubscribes from console events while being destroyed.
    /// </summary>
    private void OnDestroy()
    {
        parser.visibilityChanged -= OnVisibilityChanged;
        parser.outputChanged -= OnOutputChanged;
    }

    /// <summary>
    /// Prevents 
    /// </summary>
    private bool commandCanceled = false;

    /// <summary>
    /// Checks for the toggle console key during frame updates.
    /// </summary>
    private void Update()
    {
        if ((Input.GetButtonDown("Toggle Console") || Input.GetKeyDown(KeyCode.Escape)) && Visible)
        {
            commandCanceled = true;
        }

        if (Input.GetButtonUp("Toggle Console") || (Input.GetKeyDown(KeyCode.Escape) && Visible))
        {
            ToggleVisible();
            if (Visible) input.ActivateInputField();
        }
    }

    #endregion MonoBehaviour Methods

    #region Console Visibility Methods

    /// <summary>
    /// Gets or sets the visibility of the console.
    /// </summary>
    public bool Visible
    {
        get
        {
            //return background.gameObject.activeSelf;
            return visible;
        }
        set
        {
            //background.gameObject.SetActive(value);
            if (value != visible)
            {
                if (value) // setting visible to true
                {
                    PlaySlideIn();
                }
                else
                {
                    PlaySlideOut();
                }
                visible = value;
            }
        }
    }
    private bool visible = false;

    /// <summary>
    /// Toggles the current visibility of the console.
    /// </summary>
    private void ToggleVisible()
    {
        Visible = !Visible;
    }

    private void PlaySlideIn()
    {
        animator.enabled = true;
        animator.Play("ConsoleSlideIn");
    }

    private void PlaySlideOut()
    {
        animator.Play("ConsoleSlideOut");
    }

    /// <summary>
    /// Executed when the <see cref="consoleParser.visibilityChanged"/> event is raised.
    /// </summary>
    /// <param name="visible">Current state of visibility.</param>
    void OnVisibilityChanged(bool visible)
    {
        Visible = visible;
    }

    #endregion Console Visibility Methods

    #region Console Output History Methods

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="newOutputHistory"></param>
    //private void UpdateOutputHistory(string[] newOutputHistory)
    //{
        
    //}

    /// <summary>
    /// Executed when the <see cref="ConsoleParser.outputChanged"/> event is raised.
    /// </summary>
    /// <param name="newOutputHistory"></param>
    private void OnOutputChanged(string[] newOutputHistory)
    {
        if (newOutputHistory == null)
        {
            output.text = "";
        }
        else
        {
            output.text = string.Join("\n", newOutputHistory);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ProcessCommand()
    {
        if (!commandCanceled && input.text != "")
        {
            parser.ProcessCommand(input.text);
        }
        commandCanceled = false;

        input.text = "";
        input.ActivateInputField();
    }

    #endregion Console Output History Methods

    private void WelcomeMessage()
    {
        // ┃━┏┓┠┨─┛┗ ┣┫
        var help = " Type 'help' for a list of available console commands. ";
        var name = Application.productName;
        var count = name.Length + " Console  ".Length;
        var repeat = count < help.Length ? help.Length : count;
        var headerBuffer = 0;
        var helpBuffer = 0;

        if (count < help.Length) headerBuffer = help.Length - count;
        if (count > help.Length) helpBuffer = count - help.Length;

        var welcome = "┏" + new string('━', repeat) + "┓\n";

        welcome += "┃ " + (name.RichTextBold() + " Console").RichTextColor(MaterialColor.DeepOrange);
        welcome += new string(' ', headerBuffer) + " ┃\n";

        welcome += "┣" + new string('━', repeat) + "┫\n";

        welcome += "┃" + help.RichTextColor(MaterialColor.Amber);
        welcome += new string(' ', helpBuffer) + "┃\n";

        welcome += "┗" + new string('━', repeat) + "┛\n";

        parser.AppendOutput(welcome);
    }
}