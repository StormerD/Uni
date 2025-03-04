---
tags: gosu
---

# Gosu Draw Template

### Draw
```
#draw(x, y, z = 0, scale_x = 1, scale_y = 1, color = 0xff_ffffff, mode = :default)
```
- x (Float) — the X coordinate.
- y (Float) — the Y coordinate.
- z (Float) (defaults to: 0) — the Z-order.
- scale_x (Float) (defaults to: 1) — the horizontal scaling factor.
- scale_y (Float) (defaults to: 1) — the vertical scaling factor.
- color (Gosu::Color, Integer) (defaults to: 0xff_ffffff)
- mode (:default, :additive) (defaults to: :default) — the blending mode to use.
---
### Rectangle
```
.draw_rect(x, y, width, height, c, z = 0, mode = :default)
```
- x (Float) — the X coordinate of the rectangle’s top left corner.
- y (Float) — the Y coordinate of the rectangle’s top left corner.
- width (Float) — the width of the rectangle.
- height (Float) — the height of the rectangle.
- c (Gosu::Color) — the color of the rectangle.
- z (Float) (defaults to: 0) — the Z-order.
- mode (:default, :additive) (defaults to: :default) — the blending mode to use.
---
### Quad (two triangles)
```
.draw_quad(x1, y1, c1, x2, y2, c2, x3, y3, c3, x4, y4, c4, z = 0, mode = :default)
```
- x1 (Float) — the X coordinate of the first vertex.
- y1 (Float) — the Y coordinate of the first vertex.
- c1 (Gosu::Color) — the color of the first vertex.
- x2 (Float) — the X coordinate of the second vertex.
- y2 (Float) — the Y coordinate of the second vertex.
- c2 (Gosu::Color) — the color of the second vertex.
- x3 (Float) — the X coordinate of the third vertex.
- y3 (Float) — the Y coordinate of the third vertex.
- c3 (Gosu::Color) — the color of the third vertex.
- x4 (Float) — the X coordinate of the fourth vertex.
- y4 (Float) — the Y coordinate of the fourth vertex.
- c4 (Gosu::Color) — the color of the fourth vertex.
- z (Float) (defaults to: 0) — the Z-order.
- mode (:default, :additive) (defaults to: :default) — the blending mode to use.
---
### Triangle
```
.draw_triangle(x1, y1, c1, x2, y2, c2, x3, y3, c3, z = 0, mode = :default)
```
- x1 (Float) — the X coordinate of the first vertex.
- y1 (Float) — the Y coordinate of the first vertex.
- c1 (Gosu::Color) — the color of the first vertex.
- x2 (Float) — the X coordinate of the second vertex.
- y2 (Float) — the Y coordinate of the second vertex.
- c2 (Gosu::Color) — the color of the second vertex.
- x3 (Float) — the X coordinate of the third vertex.
- y3 (Float) — the Y coordinate of the third vertex.
- c3 (Gosu::Color) — the color of the third vertex.
- z (Float) (defaults to: 0) — the Z-order.
- mode (:default, :additive) (defaults to: :default) — the blending mode to use.