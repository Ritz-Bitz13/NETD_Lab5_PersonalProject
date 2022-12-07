#region Comment Header
/*
    * Name: Martin Barber
    * Student ID's:	100368442
    * Class: NETD 3202 - 04
    * Date: Started Sept 28th, Finished October 1st.
    * File Name: Lab_1(Class Page - Program)
    * GitHub: https://github.com/Ritz-Bitz13/NETD3202-Work/tree/master/Lab1_CODE_IT_INC
*/
#endregion

#region Using
//These are default (keep them!)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;
#endregion

#region Main Class
//keep the default namespace too, BillingApp is just the name of my project.
namespace Lab1_CODE_IT_INC
{
    public class Program
    {
        // Create the list to hold all the information.
        public static List<Program> Projects = new List<Program>();



        //First private data member
        private string projectName;

        private double theBudget;

        private double amountSpent;

        private double hoursRemaining;

        private string projectStatus;

        //constructor, you need to complete it this is a no parameter constructor shown below.
        public Program()
        {
            // To make sure there is no NULL, Setting defaults
            projectName = string.Empty;
            theBudget = 0;
            amountSpent = 0;
            hoursRemaining = 0;
            projectStatus = string.Empty;
        }

        /// <summary>
        /// Constructor with all variable to input
        /// </summary>
        /// <param name="projectname">Write down the Product Name </param>
        /// <param name="thebudget">Enter the Amount the budget is </param>
        /// <param name="amountspent">Enter the amount you have spent</param>
        /// <param name="hoursremaining">Enter how many hours you have remaining</param>
        /// <param name="projectstatus">Enter the Project Status</param>
        public Program(string projectname, double thebudget, double amountspent, double hoursremaining, string projectstatus)
        {
            projectName = projectname;
            theBudget = thebudget;
            amountSpent = amountspent;
            hoursRemaining = hoursremaining;
            projectStatus = projectstatus;
        }
        //Getters and Setters for each private data member go below.
        /*This one is an example, notice that the data member is called private
        string “projectName” the getter/setter property is named
        “ProjectName”(different capitalization).*/
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public double TheBudget
        {
            get { return this.theBudget; }
            set { this.theBudget = value; }
        }
        public double AmountSpent
        {
            get { return this.amountSpent; }
            set { this.amountSpent = value; }
        }
        public double HoursRemaining
        {
            get { return this.hoursRemaining; }
            set { this.hoursRemaining = value; }
        }
        public string ProjectStatus
        {
            get { return this.projectStatus; }
            set { this.projectStatus = value; }
        }
        #endregion

        #region Find the Project to edit 
        /// <summary>
        /// This will find the Project and extract the information from it and display it when called
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Program Find(string Name)
        {
            // Starts a new search
            Program findproject = new Program();
            
            foreach (Program p in Projects) // Checks through the list to see if any project names match what is being searched.
            { 
                if (p.ProjectName == Name) // If a name matches, return it.
                {
                    return p;
                }
            }
            return findproject;
        }
        #endregion
    }
}