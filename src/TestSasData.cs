/* Copyright 2012 SAS Institute Inc. */
using System;
using System.Collections.Generic;
using System.Text;
using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit;

namespace SAS.Tasks.TestTasks
{
    // a unique identifier for this task, formatted as a GUID
    [ClassId("97021386-7fba-45a6-a820-597e1c21f22e")]
    // the version of the task
    [Version(4.3)]
    // What does this task require for input? Typical types are Data and None.
    [InputRequired(InputResourceType.None)]
    [IconLocation("SasDataExample.task.ico")]
    public class TestSasData : SAS.Tasks.Toolkit.SasTask
    {
        public TestSasData()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 
            // TestSasData
            // 
            this.TaskCategory = "SAS Examples";
            this.TaskDescription = "Show access to SAS data";
            this.TaskName = "Show SasData access";

        }

        public override ShowResult Show(System.Windows.Forms.IWin32Window Owner)
        {
            TestSasDataForm dlg = new TestSasDataForm();
            dlg.Consumer = Consumer;
            dlg.ShowDialog(Owner);
            return ShowResult.Canceled;
        }

    }
}
