/* Copyright 2012 SAS Institute Inc. */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit;
using SAS.Tasks.Toolkit.Data;
using System.Collections.ObjectModel;

namespace SAS.Tasks.TestTasks
{
    public partial class TestSasDataForm : SAS.Tasks.Toolkit.Controls.TaskForm
    {
        public TestSasDataForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Set up controls for data binding use
            lbItems.DisplayMember = "Name";
            lbLibraries.DisplayMember = "Name";
            lbMembers.DisplayMember = "Member";
            cmbServer.DisplayMember = "Name";

            // populate comb box with SasServer objects
            foreach (SasServer s in SasServer.GetSasServers())
            {
                cmbServer.Items.Add(s);
            }
            cmbServer.Text = Consumer.AssignedServer;
            Text = "Explore SAS Data Properties";

            PopulateLibraries();
            cmbServer.SelectedIndexChanged += new EventHandler(OnServerChanged);
        }

        // when Server selection is changed, clear out the 
        // libraries and members
        // and fetch new library names
        void OnServerChanged(object sender, EventArgs e)
        {
            PopulateLibraries();
        }

        private void PopulateLibraries()
        {
            // use the SasServer.GetSasLibraries method 
            // to get a collection of defined SAS libraries
            // on the active server
            SasServer s = cmbServer.SelectedItem as SasServer;
            IList<SasLibrary> libs = s.GetSasLibraries();
            lbLibraries.Items.Clear();
            lbLibraries.Items.AddRange(new List<SasLibrary>(libs).ToArray());

            // clear Members list, out of sync with previous selection
            lbMembers.Items.Clear();
        }

        // When selected column changes, update
        // the property viewer with the new SasColumn object
        private void onSelectedColumnChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedItem != null)
                // put selected column in Column properties
                pgColumn.SelectedObject = lbItems.SelectedItem;
            else lbItems.ClearSelected();
        }

        // When selected library changes, get a new list
        // of data members (DATA or VIEW types)
        private void onSelectedLibraryChanged(object sender, EventArgs e)
        {
            lbMembers.Items.Clear();
            SasLibrary lib = lbLibraries.SelectedItem as SasLibrary;

            // put selected library in Library properties
            pgLib.SelectedObject = lib;

            if (!lib.IsAssigned)
            {
                try
                {
                    lib.Assign();
                }
                catch { }
            }
            if (lib.IsAssigned)
            {
                // gets a collection of SasData objects
                lbMembers.Items.AddRange(new List<SasData>(lib.GetSasDataMembers()).ToArray());
            }
        }

        // When selected data member changes, get
        // a new list of columns
        private void onSelectedDatasetChanged(object sender, EventArgs e)
        {
            lbItems.Items.Clear();
            SasData d = lbMembers.SelectedItem as SasData;
            // gets a collection of SasColumn objects
            lbItems.Items.AddRange(new List<SasColumn>(d.GetColumns()).ToArray());
        }

        // for the selected LIBNAME.MEMBER and COLUMN
        // get the Distinct values from the data set
        // This will optionally apply a format as well
        // if one is specified
        private void btnGetValues_Click(object sender, EventArgs e)
        {
             lbValues.Items.Clear();
            SasColumn c = lbItems.SelectedItem as SasColumn;
            SasLibrary lib = lbLibraries.SelectedItem as SasLibrary;
            SasData d = lbMembers.SelectedItem as SasData;

            if (c != null && lib!=null)
            {
                // Fetch distinct values using SAS format
                string format = "";

                // get a handle to the selected data
                ISASTaskData2 td = 
                    Consumer.LibrefData(Consumer.AssignedServer,lib.Libref,d.Member) as ISASTaskData2;

                // set the format if not blank
                if (!string.IsNullOrEmpty(txtformat.Text))
                    format = txtformat.Text;

                // this can throw an exception if the
                // selected format does not match
                // the data type.
                try
                {
                    lbValues.Items.AddRange(
                        new List<string>(
                            SAS.Tasks.Toolkit.Helpers.TaskDataHelpers.GetDistinctValues(Consumer, td, c.Name, format)).ToArray()
                            );
                }
                catch (SasDataException)
                {
                    lbValues.Items.Add("<ERROR: could not fetch values>");
                }
            }
        }
    }
}