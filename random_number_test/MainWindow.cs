using System;
using System.Timers;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    private Timer timer;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        InitializeTimer(timer);
    }

    private void InitializeTimer(Timer timer)
    {
        timer = new Timer(1000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;

    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        string newString = "";
        Random random = new Random();

        for (int i=0; i<60; i++)
        {
            newString += (char)random.Next(48, 91);
        }

        InsertText(textview.Buffer, newString);
    }

    private void OnSizeAllocated(object sender, SizeAllocatedArgs e)
    {
        textview.ScrollToIter(textview.Buffer.EndIter, 0, false, 0, 0);
    }

    private static void InsertText(TextBuffer textBuffer, string line)
    {
        TextIter textIter = textBuffer.EndIter;
        textBuffer.Insert(ref textIter, line);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
