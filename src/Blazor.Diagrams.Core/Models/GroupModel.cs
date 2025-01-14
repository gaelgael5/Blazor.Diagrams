﻿using Blazor.Diagrams.Core.Extensions;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Diagrams.Core.Models
{

    public class GroupModel : NodeModel
    {

        private readonly List<NodeModel> _children;

        public GroupModel(IEnumerable<NodeModel> children, byte padding = 30)
        {
            _children = new List<NodeModel>();

            Size = Size.Zero;
            Padding = padding;
            Initialize(children);
        }

        public IReadOnlyList<NodeModel> Children => _children;
        public byte Padding { get; }

        public IEnumerable<BaseLinkModel> HandledLinks => _children.SelectMany(c => c.AllLinks).Distinct();

        public void AddChild(NodeModel child)
        {
            _children.Add(child);
            child.Group = this;
            child.SizeChanged += OnNodeChanged;
            child.Moving += OnNodeChanged;

            if (UpdateDimensions())
            {
                Refresh();
            }
        }

        public void RemoveChild(NodeModel child)
        {
            if (!_children.Remove(child))
                return;

            child.Group = null;
            child.SizeChanged -= OnNodeChanged;
            child.Moving -= OnNodeChanged;

            if (UpdateDimensions())
            {
                Refresh();
            }
        }

        public override void SetPosition(double x, double y)
        {
            var deltaX = x - Position.X;
            var deltaY = y - Position.Y;
            base.SetPosition(x, y);

            foreach (var node in Children)
                node.UpdatePositionSilently(deltaX, deltaY);

            Refresh();
            RefreshLinks();
        }

        public override void UpdatePositionSilently(double deltaX, double deltaY)
        {
            base.UpdatePositionSilently(deltaX, deltaY);

            foreach (var child in Children)
                child.UpdatePositionSilently(deltaX, deltaY);
        }

        public void Ungroup()
        {
            foreach (var child in Children)
            {
                child.Group = null;
                child.SizeChanged -= OnNodeChanged;
                child.Moving -= OnNodeChanged;
            }

            _children.Clear();
        }

        private void Initialize(IEnumerable<NodeModel> children)
        {
            foreach (var child in children)
            {
                _children.Add(child);
                child.Group = this;
                child.SizeChanged += OnNodeChanged;
                child.Moving += OnNodeChanged;
            }

            UpdateDimensions();
        }

        private void OnNodeChanged(NodeModel node)
        {
            if (UpdateDimensions())
            {
                Refresh();
            }
        }

        internal NodeModel? ResolveNode(Guid id)
        {
            foreach (NodeModel node in this._children)
            {

                if (node.Id == id)
                    return node;

                else if (node is GroupModel group)
                {
                    var result = group.ResolveNode(id);
                    if (result != null)
                        return result;
                }

            }

            return null;

        }

        internal PortModel? ResolvePort(Guid id)
        {

            foreach (NodeModel node in this._children)
            {

                foreach (var port in node.Ports)
                    if (port.Id == id)
                        return port;

                if (node is GroupModel group)
                {
                    var result = group.ResolvePort(id);
                    if (result != null)
                        return result;
                }

            }

            return null;

        }

        private bool UpdateDimensions()
        {
            if (Children.Any(n => n.Size == null))
                return false;

            var bounds = Children.GetBounds();
            Size = new Size(bounds.Width + Padding * 2, bounds.Height + Padding * 2);
            Position = new GPoint(bounds.Left - Padding, bounds.Top - Padding);
            return true;
        }

    }
}
