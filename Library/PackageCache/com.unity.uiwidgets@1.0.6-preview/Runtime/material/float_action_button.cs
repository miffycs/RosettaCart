using System.Collections.Generic;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace Unity.UIWidgets.material {
    static class FloatActionButtonUtils {
        public static readonly BoxConstraints _kSizeConstraints = BoxConstraints.tightFor(width: 56.0f, height: 56.0f);

        public static readonly BoxConstraints _kMiniSizeConstraints =
            BoxConstraints.tightFor(width: 40.0f, height: 40.0f);

        public static readonly BoxConstraints _kExtendedSizeConstraints =
            new BoxConstraints(minHeight: 48.0f, maxHeight: 48.0f);
    }


    class _DefaultHeroTag {
        public _DefaultHeroTag() {
        }

        public override string ToString() {
            return "<default FloatingActionButton tag>";
        }
    }

    public class FloatingActionButton : StatelessWidget {
        FloatingActionButton(
            Key key = null,
            Widget child = null,
            string tooltip = null,
            Color foregroundColor = null,
            Color backgroundColor = null,
            object heroTag = null,
            float elevation = 6.0f,
            float highlightElevation = 12.0f,
            float? disabledElevation = null,
            VoidCallback onPressed = null,
            bool mini = false,
            ShapeBorder shape = null,
            Clip clipBehavior = Clip.none,
            MaterialTapTargetSize? materialTapTargetSize = null,
            bool isExtended = false,
            BoxConstraints _sizeConstraints = null
        ) : base(key: key) {
            D.assert(elevation >= 0.0f);
            D.assert(highlightElevation >= 0.0f);
            D.assert(disabledElevation == null || disabledElevation >= 0.0f);
            heroTag = heroTag ?? new _DefaultHeroTag();
            shape = shape ?? new CircleBorder();
            this.child = child;
            this.tooltip = tooltip;
            this.foregroundColor = foregroundColor;
            this.backgroundColor = backgroundColor;
            this.heroTag = heroTag;
            this.elevation = elevation;
            this.highlightElevation = highlightElevation;
            this.onPressed = onPressed;
            this.mini = mini;
            this.shape = shape;
            this.clipBehavior = clipBehavior;
            this.materialTapTargetSize = materialTapTargetSize;
            this.isExtended = isExtended;
            this.disabledElevation = disabledElevation;
            this._sizeConstraints = _sizeConstraints ?? (mini
                                        ? FloatActionButtonUtils._kMiniSizeConstraints
                                        : FloatActionButtonUtils._kSizeConstraints);
        }

        public FloatingActionButton(
            Key key = null,
            Widget child = null,
            string tooltip = null,
            Color foregroundColor = null,
            Color backgroundColor = null,
            object heroTag = null,
            float elevation = 6.0f,
            float highlightElevation = 12.0f,
            VoidCallback onPressed = null,
            bool mini = false,
            ShapeBorder shape = null,
            Clip clipBehavior = Clip.none,
            MaterialTapTargetSize? materialTapTargetSize = null,
            bool isExtended = false
        ) : this(key: key,
            child: child,
            tooltip: tooltip,
            foregroundColor: foregroundColor,
            backgroundColor: backgroundColor,
            heroTag: heroTag,
            elevation: elevation,
            highlightElevation: highlightElevation,
            onPressed: onPressed,
            mini: mini,
            shape: shape,
            clipBehavior: clipBehavior,
            materialTapTargetSize: materialTapTargetSize,
            isExtended: isExtended,
            _sizeConstraints: null) {
        }

        public static FloatingActionButton extended(
            Key key = null,
            string tooltip = null,
            Color foregroundColor = null,
            Color backgroundColor = null,
            object heroTag = null,
            float elevation = 6.0f,
            float highlightElevation = 12.0f,
            float? disabledElevation = null,
            VoidCallback onPressed = null,
            ShapeBorder shape = null,
            bool isExtended = true,
            MaterialTapTargetSize? materialTapTargetSize = null,
            Clip clipBehavior = Clip.none,
            Widget icon = null,
            Widget label = null
        ) {
            D.assert(elevation >= 0.0f);
            D.assert(highlightElevation >= 0.0f);
            D.assert(disabledElevation == null || disabledElevation >= 0.0f);
            D.assert(icon != null);
            D.assert(label != null);
            heroTag = heroTag ?? new _DefaultHeroTag();
            shape = shape ?? new StadiumBorder();

            BoxConstraints _sizeConstraints = FloatActionButtonUtils._kExtendedSizeConstraints;
            bool mini = false;
            Widget child = new _ChildOverflowBox(
                child: new Row(
                    mainAxisSize: MainAxisSize.min,
                    children: new List<Widget> {
                        new SizedBox(width: 16.0f),
                        icon,
                        new SizedBox(width: 8.0f),
                        label,
                        new SizedBox(width: 20.0f)
                    }));

            return new FloatingActionButton(
                key: key,
                child: child,
                tooltip: tooltip,
                foregroundColor: foregroundColor,
                backgroundColor: backgroundColor,
                heroTag: heroTag,
                elevation: elevation,
                highlightElevation: highlightElevation,
                disabledElevation: disabledElevation ?? elevation,
                onPressed: onPressed,
                mini: mini,
                shape: shape,
                clipBehavior: clipBehavior,
                materialTapTargetSize: materialTapTargetSize,
                isExtended: isExtended,
                _sizeConstraints: _sizeConstraints
            );
        }

        public readonly Widget child;

        public readonly string tooltip;

        public readonly Color foregroundColor;

        public readonly Color backgroundColor;

        public readonly object heroTag;

        public readonly VoidCallback onPressed;

        public readonly float elevation;

        public readonly float highlightElevation;

        public readonly float? disabledElevation;

        public readonly bool mini;

        public readonly ShapeBorder shape;

        public readonly Clip clipBehavior;

        public readonly bool isExtended;

        public readonly MaterialTapTargetSize? materialTapTargetSize;

        public readonly BoxConstraints _sizeConstraints;

        public override Widget build(BuildContext context) {
            ThemeData theme = Theme.of(context);
            Color foregroundColor = this.foregroundColor ?? theme.accentIconTheme.color;
            Widget result = null;

            if (this.child != null) {
                result = IconTheme.merge(
                    data: new IconThemeData(
                        color: foregroundColor),
                    child: this.child
                );
            }

            result = new RawMaterialButton(
                onPressed: this.onPressed,
                elevation: this.elevation,
                highlightElevation: this.highlightElevation,
                disabledElevation: this.disabledElevation ?? this.elevation,
                constraints: this._sizeConstraints,
                materialTapTargetSize: this.materialTapTargetSize ?? theme.materialTapTargetSize,
                fillColor: this.backgroundColor ?? theme.accentColor,
                textStyle: theme.accentTextTheme.button.copyWith(
                    color: foregroundColor,
                    letterSpacing: 1.2f),
                shape: this.shape,
                clipBehavior: this.clipBehavior,
                child: result);

            if (this.tooltip != null) {
                result = new Tooltip(
                    message: this.tooltip,
                    child: result);
            }

            if (this.heroTag != null) {
                result = new Hero(
                    tag: this.heroTag,
                    child: result);
            }

            return result;
        }
    }

    class _ChildOverflowBox : SingleChildRenderObjectWidget {
        public _ChildOverflowBox(
            Key key = null,
            Widget child = null) : base(key: key, child: child) {
        }

        public override RenderObject createRenderObject(BuildContext context) {
            return new _RenderChildOverflowBox();
        }

        public override void updateRenderObject(BuildContext context, RenderObject renderObject) {
        }
    }


    class _RenderChildOverflowBox : RenderAligningShiftedBox {
        public _RenderChildOverflowBox(
            RenderBox child = null) : base(child: child, alignment: Alignment.center) {
        }

        protected override float computeMinIntrinsicWidth(float height) {
            return 0.0f;
        }

        protected override float computeMinIntrinsicHeight(float width) {
            return 0.0f;
        }

        protected override void performLayout() {
            if (this.child != null) {
                this.child.layout(new BoxConstraints(), parentUsesSize: true);
                this.size = new Size(
                    Mathf.Max(this.constraints.minWidth, Mathf.Min(this.constraints.maxWidth, this.child.size.width)),
                    Mathf.Max(this.constraints.minHeight, Mathf.Min(this.constraints.maxHeight, this.child.size.height))
                );
                this.alignChild();
            }
            else {
                this.size = this.constraints.biggest;
            }
        }
    }
}