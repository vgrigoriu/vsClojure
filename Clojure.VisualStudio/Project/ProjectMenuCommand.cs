﻿using System.ComponentModel.Design;
using Clojure.VisualStudio.Project.Hierarchy;
using Clojure.VisualStudio.Project.Launching;
using EnvDTE;
using Microsoft.VisualStudio.Project;

namespace Clojure.VisualStudio.Project
{
    public class ProjectMenuCommand
    {
        private readonly UIHierarchy _solutionExplorer;
        private readonly IProjectUserCommandListener _launchListener;
        public static CommandID LaunchReplCommandId = new CommandID(Guids.GuidClojureExtensionCmdSet, 10);

        public ProjectMenuCommand(UIHierarchy solutionExplorer, IProjectUserCommandListener launchListener)
        {
            _solutionExplorer = solutionExplorer;
            _launchListener = launchListener;
        }

        public void Click()
        {
            var selectedProject = _solutionExplorer.GetSelectedProject();
            var projectNode = ((ProjectNode) selectedProject.Object);
            var frameworkPath = projectNode.CreateLaunchParameters().FrameworkPath;
            var projectPath = selectedProject.FullName;
            _launchListener.LaunchRepl(new ProjectSnapshot(projectPath, frameworkPath));
        }
    }
}