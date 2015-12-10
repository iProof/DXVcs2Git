﻿using System.Collections.Generic;
using DXVcs2Git.Core;
using NUnit.Framework;
using Polenter.Serialization;

namespace DXVcs2Git.Tests {
    [TestFixture]
    public class TrackConfigTests {
        [Test, Explicit]
        public void GenerateTestConfig() {
            List<TrackItem> items = new List<TrackItem>();
            items.Add(new TrackItem() { Path = @"$/Sandbox/litvinov/XPF/DevExpress.Xpf.Core", ProjectPath = "DevExpress.Xpf.Core" });
            TrackBranch branch = new TrackBranch("2015.2", "$/Sandbox/litvinov/XPF/track2015.2.config", "$/Sandbox/litvinov/XPF", items);

            SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
            settings.IncludeAssemblyVersionInTypeName = false;
            settings.IncludePublicKeyTokenInTypeName = false;
            SharpSerializer serializer = new SharpSerializer(settings);
            serializer.Serialize(new List<TrackBranch>() { branch }, @"c:\1\trackconfig_testxpf.config");
        }
        [Test, Explicit]
        public void GenerateXpfCommon141Config() {
            GenerateXpfCommonConfig("2014.1");
        }
        [Test, Explicit]
        public void GenerateXpfCommon152Config() {
            GenerateXpfCommonConfig("2015.2");
        }
        [Test, Explicit]
        public void GenerateXpfCommon151Config() {
            GenerateXpfCommonConfig("2015.1");
        }
        [Test, Explicit]
        public void GenerateXpfCommon142Config() {
            GenerateXpfCommonConfig("2014.2");
        }
        void GenerateXpfCommonConfig(string branchName) {
            List<TrackItem> items = new List<TrackItem>();
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Mvvm", ProjectPath = "DevExpress.Mvvm" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Core", ProjectPath = "DevExpress.Xpf.Core" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Controls", ProjectPath = "DevExpress.Xpf.Controls" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Grid", ProjectPath = "DevExpress.Xpf.Grid" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.NavBar", ProjectPath = "DevExpress.Xpf.NavBar" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.PropertyGrid", ProjectPath = "DevExpress.Xpf.PropertyGrid" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Ribbon", ProjectPath = "DevExpress.Xpf.Ribbon" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Layout", ProjectPath = "DevExpress.Xpf.Layout" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.LayoutControl", ProjectPath = "DevExpress.Xpf.LayoutControl" });
            TrackBranch branch = new TrackBranch($"{branchName}", $@"$/{branchName}/Common/xpf_common_sync.config", $@"$/{branchName}/XPF", items);

            SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
            settings.IncludeAssemblyVersionInTypeName = false;
            settings.IncludePublicKeyTokenInTypeName = false;
            SharpSerializer serializer = new SharpSerializer(settings);
            serializer.Serialize(new List<TrackBranch>() { branch }, $@"z:\trackconfig_common_{branchName}.config");

        }
        [Test, Explicit]
        public void GenerateXpfDiagram152Config() {
            GenerateXpfDiagramConfig("2015.2");
        }
        void GenerateXpfDiagramConfig(string branchName) {
            List<TrackItem> items = new List<TrackItem>();
            items.Add(new TrackItem() { Path = $@"$/{branchName}/Win/DevExpress.XtraDiagram", ProjectPath = "DevExpress.XtraDiagram", AdditionalOffset = "Win"});
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Diagram", ProjectPath = "DevExpress.Xpf.Diagram", AdditionalOffset = "XPF"});
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.ReportDesigner", ProjectPath = "DevExpress.Xpf.ReportDesigner", AdditionalOffset = "XPF"});
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.PdfViewer", ProjectPath = "DevExpress.Xpf.PdfViewer", AdditionalOffset = "XPF" });
            items.Add(new TrackItem() { Path = $@"$/{branchName}/XPF/DevExpress.Xpf.Printing", ProjectPath = "DevExpress.Xpf.Printing", AdditionalOffset = "XPF" });
            TrackBranch branch = new TrackBranch($"{branchName}", $@"$/{branchName}/Diagram/xpf_common_sync.config", $@"$/{branchName}", items);

            SharpSerializerXmlSettings settings = new SharpSerializerXmlSettings();
            settings.IncludeAssemblyVersionInTypeName = false;
            settings.IncludePublicKeyTokenInTypeName = false;
            SharpSerializer serializer = new SharpSerializer(settings);
            serializer.Serialize(new List<TrackBranch>() { branch }, $@"z:\trackconfig_diagram_{branchName}.config");

        }

    }
}
