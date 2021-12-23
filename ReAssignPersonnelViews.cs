using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logging;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Sdmsols.XTB.ReAssignPersonnelViews.Helpers;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Sdmsols.XTB.ReAssignPersonnelViews
{
    public partial class ReAssignPersonnelViews : PluginControlBase,IGitHubPlugin, IPayPalPlugin, IMessageBusHost, IHelpPlugin, IStatusBarMessenger, IAboutPlugin
    {
        #region Constructor and Class Variables

        private Settings _mySettings;


        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            //throw new NotImplementedException();
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;


        private enum ControlSelected
        {
            Solutions=1,
            Entities=2,
            Attributes=3

        }

        public ReAssignPersonnelViews()
        {
            InitializeComponent();
        }

        #endregion Constructor and Class Variables

        #region XrmToolBox Plug In Methods

        private void ReAssignPersonnelViews_Load(object sender, EventArgs e)
        {
           // ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out _mySettings))
            {
                _mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (_mySettings != null && detail != null)
            {
                _mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void ReAssignPersonnelViews_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            LoadUsersAndTeams();
        }

        
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReAssignPersonnelViews_OnCloseTool(object sender, System.EventArgs e)
        {

            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), _mySettings);
        }
        
        #endregion XrmToolBox Plug In Methods
        
        #region Control Events

        private void cmbSourceUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
          LoadViews();
        }

        private void tslAbout_Click(object sender, EventArgs e)
        {
            Process.Start(HelpUrl);
        }

        private void btnTransferViews_Click(object sender, EventArgs e)
        {
            TransferViews();
        }
        


        #endregion Control Events

        #region Private Helper Methods

        //private void LoadUsers()
        //{
        //    cmbSourceUsers.Items.Clear();
        //    cmbSourceUsers.Enabled = false;
        //    WorkAsync(new WorkAsyncInfo("Loading solutions...",
        //        (eventargs) =>
        //        {
        //            var qx = new QueryExpression("systemuser");
        //            qx.ColumnSet.AddColumns("fullname", "systemuserid");
        //            qx.AddOrder("fullname", OrderType.Ascending);
        //            qx.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);

        //            eventargs.Result = Service.RetrieveMultiple(qx);
        //        })
        //    {
        //        PostWorkCallBack = (completedargs) =>
        //        {
        //            if (completedargs.Error != null)
        //            {
        //                MessageBox.Show(completedargs.Error.Message);
        //            }
        //            else
        //            {
        //                if (completedargs.Result is EntityCollection)
        //                {
        //                    var users = (EntityCollection)completedargs.Result;
        //                    var proxiedusers = users.Entities.Select(s => new UserProxy(s)).OrderBy(s => s.ToString());
        //                    cmbSourceUsers.Items.AddRange(proxiedusers.ToArray());
        //                    cmbSourceUsers.Enabled = true;
        //                }
        //            }

        //        }
        //    });
        //}



        private void LoadUsersAndTeams()
        {
            cmbSourceUsers.Items.Clear();
            cmbSourceUsers.Enabled = false;
            cmbDestinationUsers.Items.Clear();
            cmbDestinationUsers.Enabled = false;
            WorkAsync(new WorkAsyncInfo("Loading solutions...",
                (eventargs) =>
                {
                    EntityCollection collection = new EntityCollection();


                    var qx = new QueryExpression("systemuser");
                    qx.ColumnSet.AddColumns("fullname", "systemuserid");
                    qx.AddOrder("fullname", OrderType.Ascending);
                    qx.Criteria.AddCondition("isdisabled", ConditionOperator.Equal, false);
                    
                    var users = Service.RetrieveMultiple(qx);
                    collection.Entities.AddRange(users.Entities);


                    var qxTeam = new QueryExpression("team");
                    qxTeam.ColumnSet.AddColumns("name", "teamid", "teamtype");
                    qxTeam.AddOrder("name", OrderType.Ascending);
                    qxTeam.Criteria.AddCondition("teamtype", ConditionOperator.NotEqual, 1);

                    var teams = Service.RetrieveMultiple(qxTeam);
                    collection.Entities.AddRange(teams.Entities);

                    eventargs.Result = collection;



                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (completedargs.Result is EntityCollection)
                        {
                            var users = (EntityCollection)completedargs.Result;
                            var proxiedUserOrTeam = users.Entities.Select(s => new UserTeamProxy(s)).OrderBy(s => s.ToString());

                            cmbSourceUsers.Items.AddRange(proxiedUserOrTeam.ToArray());
                            cmbSourceUsers.Enabled = true;
                            cmbDestinationUsers.Items.AddRange(proxiedUserOrTeam.ToArray());
                            cmbDestinationUsers.Enabled = true;
                        }
                    }

                }
            });
        }

        private void LoadViews()
        {
            if (cmbSourceUsers.SelectedItem == null)
            {
                return;
            }
            var user = cmbSourceUsers.SelectedItem as UserTeamProxy;
            if (user == null)
            {
                return;
            }
            
            WorkAsync(new WorkAsyncInfo("Filtering entities...",
                (eventargs) =>
                {
                    
                    var qx = new QueryExpression("solutioncomponent");

                    // Share the same access rights as the user, so we must retrieve the user's access rights to the record
                    QueryExpression qe = new QueryExpression("userquery");
                    qe.ColumnSet.AllColumns = true;
                    qe.Orders.Add(new OrderExpression("name", OrderType.Ascending));

                    FilterExpression filter = new FilterExpression();
                    
                    ConditionExpression hasActiveStatus = new ConditionExpression();
                    hasActiveStatus.AttributeName = "statuscode";
                    hasActiveStatus.Operator = ConditionOperator.In;
                    hasActiveStatus.Values.AddRange(1, 2);
                    
                    //ownerid is same as passed in user
                    ConditionExpression hasOwner = new ConditionExpression();
                    hasOwner.AttributeName = "ownerid";
                    hasOwner.Operator = ConditionOperator.In;
                    hasOwner.Values.AddRange(user.Id);
                    

                    filter.Conditions.Add(hasActiveStatus);
                    filter.Conditions.Add(hasOwner);
                    
                    qe.Criteria = filter;

                    //impersonated the Call by passing user id!
                    var crmServiceClient = this.ConnectionDetail.GetCrmServiceClient();
                    crmServiceClient.CallerId = new Guid(user.Id);
                    
                    eventargs.Result = crmServiceClient.RetrieveMultiple(qe);
                    
                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (completedargs.Result is EntityCollection)
                        {
                            var userViewList = (EntityCollection)completedargs.Result;
                            var proxiedViews = userViewList.Entities.Select(s => new UserViewProxy(s))
                                .OrderBy(s => s.ToString()).ToList();

                            AddItemToChekListBox(proxiedViews);
                        }
                    }
                    
                }
            });
        }

        protected virtual void AddItemToChekListBox(List<UserViewProxy> collection)
        {   
            chlSourceViewList.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {
                chlSourceViewList.Items.Clear();


                foreach (var userView in collection)
                {
                    //crmView = new CRMView();
                    // chlSourceViewList.Items.Add(userView["name"].ToString() + " (" + userView["returnedtypecode"] + ") " + " INTERNAL ID=" + userView.Id);
                    //crmView.Id = userView.Id.ToString();
                    //crmView.Name = userView["name"].ToString();
                    //crmView.EntityName = userView["returnedtypecode"].ToString();

                    chlSourceViewList.Items.Add(userView);
                }


            });
        }


        private void btnRetrieveViews_Click(object sender, EventArgs e)
        {
            LoadViews();
        }


        #endregion Private Helper Methods
        
        #region Logging And ProgressBar Methods
        delegate void SetStatusTextCallback(string text);

        delegate void AddProgressStepCallback();

        private void UpdateStatusMessage(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.StatusText.InvokeRequired)
            {
                SetStatusTextCallback d = new SetStatusTextCallback(UpdateStatusMessage);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //this.StatusText.Text = text;

                StatusText.Text = StatusText.Text + text + Environment.NewLine;

                StatusText.Focus();
                StatusText.ScrollToCaret();
                ErrorLog.ReportRoutine(false, text, EventLogEntryType.Information);

                Application.DoEvents();


            }
        }
        
        private void AddProgressStep()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.progressBar.InvokeRequired)
            {
                AddProgressStepCallback d = new AddProgressStepCallback(AddProgressStep);
                this.Invoke(d);
            }
            else
            {
                progressBar.PerformStep();
                Application.DoEvents();
            }
        }

        #endregion Logging And ProgressBar Methods
        
        #region Interface Members

        public string RepositoryName => "ReAssignPersonnelViews";

        public string UserName => "contactmayankp";
        
        public string DonationDescription => "Re-Assign Personnel Views";
        public string EmailAccount => "mayank.pujara@gmail.com";

        public string HelpUrl => "https://mayankp.wordpress.com/2021/12/23/xrmtoolbox-new-tool-reassignpersonnelviews/";


        public void ShowAboutDialog()
        {
            // throw new NotImplementedException();
        }

        #endregion
        
        #region Helper Methods

        private void TransferViews()
        {
            var userTeamProxy = cmbDestinationUsers.SelectedItem as UserTeamProxy;
            if (userTeamProxy == null)
            {
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Transferring Selected views to " + userTeamProxy.ToString(),
                Work = (worker, args) =>
                {

                    var result = GetSelectedViews();
                    args.Result = result;

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as List<UserViewProxy>;

                    if (result != null && result.Count > 0)
                    {
                        
                        LogTextBoxAndProgressBar.UpdateStatusMessage(StatusText, $"Found {result.Count} Views selected...");

                        LogTextBoxAndProgressBar.SetProgressBar(progressBar, result.Count);


                        TransferViewsToNewUser(userTeamProxy, result);
                    }
                    else
                    {
                        LogTextBoxAndProgressBar.UpdateStatusMessage(StatusText,
                            $"No View(s) are selected, Please Selected views and then try again!");
                    }
                }
            });
        }
        
        private void TransferViewsToNewUser(UserTeamProxy userTeamProxy, List<UserViewProxy> selectedViews)
        {
            
            if (userTeamProxy == null)
            {
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Started Transferring Selected views to " + userTeamProxy.ToString(),
                Work = (worker, args) =>
                {
                    foreach (var selectedView in selectedViews)
                    {   
                        UpdateStatusMessage($"Started Transfer View : {selectedView.Name} to new User/Team :{userTeamProxy.ToString()}..");

                        try
                        {
                            var assignRequest = new AssignRequest
                            {
                                Target = new EntityReference("userquery", new Guid(selectedView.Id)),
                                Assignee = userTeamProxy.UserOrTeamEntity.ToEntityReference()
                            };
                            
                            var assignResponse = (AssignResponse)Service.Execute(assignRequest);
                            
                            UpdateStatusMessage($"Completed Transfer View : {selectedView.Name} to new User/Team :{userTeamProxy.ToString()} Records which are missing auto numbers..");
                        }
                        catch (Exception e)
                        {
                            UpdateStatusMessage($" an Error Occurred while Transferring View : {selectedView.Name} to new User/Team :{userTeamProxy.ToString()} .. Error: {e.Message}");
                        }

                        AddProgressStep();
                    }

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    LoadViews();
                }
            });
        }

        private List<UserViewProxy> GetSelectedViews()
        {
            List<UserViewProxy> selectViews = new List<UserViewProxy>();
            

            chlSourceViewList.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {   
                foreach (var selectItem in chlSourceViewList.CheckedItems)
                {
                    selectViews.Add((UserViewProxy)selectItem);
                }

            });

            return selectViews;
        }

        #endregion Helper Methods
    }
}