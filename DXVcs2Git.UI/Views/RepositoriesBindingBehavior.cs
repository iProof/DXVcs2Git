﻿using System.Linq;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using DXVcs2Git.UI.ViewModels;

namespace DXVcs2Git.UI.Views {
    public class RepositoriesBindingBehavior : Behavior<GridControl> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.CurrentItemChanged += AssociatedObjectOnCurrentItemChanged;
        }
        void AssociatedObjectOnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e) {
            UpdateSelection();
        }
        void UpdateSelection() {
            MergeRequestsViewModel model = AssociatedObject.DataContext as MergeRequestsViewModel;
            if (model == null)
                return;
            var treeList = (TreeListView)AssociatedObject.View;
            var node = treeList.GetNodeByRowHandle(treeList.FocusedRowHandle);
            if (node.HasChildren) {
                var repository = (RepositoryViewModel)node.Content;
                model.SelectedRepository = repository;
                repository.SelectedBranch = repository.Branches.FirstOrDefault();
            }
            else {
                var branch = node.Content as BranchViewModel;
                if (branch != null) {
                    var repository = (RepositoryViewModel)node.ParentNode.Content;
                    model.SelectedRepository = repository;
                    repository.SelectedBranch = repository.Branches.FirstOrDefault();
                }
                else {
                    var repository = (RepositoryViewModel)node.Content;
                    model.SelectedRepository = repository;
                    repository.SelectedBranch = null;
                }
            }
        }
        protected override void OnDetaching() {
            AssociatedObject.CurrentItemChanged -= AssociatedObjectOnCurrentItemChanged;
            base.OnDetaching();
        }
    }
}