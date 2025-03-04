require "rubygems"
require "gosu"
require "./circle"

module ZOrder
    BACKGROUND, MIDDLE, TOP = *0..2
end

class DemoWindow < Gosu::Window
    def initialize
        super(640, 400, false)
    end

    def draw

        # windscreen
        Gosu.draw_rect(230, 160, 100, 50, Gosu::Color::WHITE, ZOrder::TOP, mode=:default)
        Gosu.draw_rect(235, 165, 90, 40, Gosu::Color::AQUA, ZOrder::TOP, mode=:default)
        # main body
        Gosu.draw_rect(200, 200, 170, 60, Gosu::Color::WHITE, ZOrder::TOP, mode=:default)
        Gosu.draw_rect(205, 205, 160, 50, Gosu::Color::GREEN, ZOrder::TOP, mode=:default)

        # triangle 1
        Gosu.draw_triangle(205, 260, Gosu::Color::WHITE, 220, 230, Gosu::Color::WHITE, 235, 260, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(210, 255, Gosu::Color::BLUE, 220, 235, Gosu::Color::BLUE, 230, 255, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 2
        Gosu.draw_triangle(220, 230, Gosu::Color::WHITE, 235, 260, Gosu::Color::WHITE, 250, 230, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(225, 235, Gosu::Color::BLUE, 235, 255, Gosu::Color::BLUE, 245, 235, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 3
        Gosu.draw_triangle(235, 260, Gosu::Color::WHITE, 250, 230, Gosu::Color::WHITE, 265, 260, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(240, 255, Gosu::Color::BLUE, 250, 235, Gosu::Color::BLUE, 260, 255, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 4
        Gosu.draw_triangle(250, 230, Gosu::Color::WHITE, 265, 260, Gosu::Color::WHITE, 280, 230, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(255, 235, Gosu::Color::BLUE, 265, 255, Gosu::Color::BLUE, 275, 235, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 5
        Gosu.draw_triangle(265, 260, Gosu::Color::WHITE, 280, 230, Gosu::Color::WHITE, 295, 260, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(270, 255, Gosu::Color::BLUE, 280, 235, Gosu::Color::BLUE, 290, 255, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 6
        Gosu.draw_triangle(280, 230, Gosu::Color::WHITE, 295, 260, Gosu::Color::WHITE, 310, 230, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(285, 235, Gosu::Color::BLUE, 295, 255, Gosu::Color::BLUE, 305, 235, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 7
        Gosu.draw_triangle(295, 260, Gosu::Color::WHITE, 310, 230, Gosu::Color::WHITE, 325, 260, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(300, 255, Gosu::Color::BLUE, 310, 235, Gosu::Color::BLUE, 320, 255, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 8
        Gosu.draw_triangle(310, 230, Gosu::Color::WHITE, 325, 260, Gosu::Color::WHITE, 340, 230, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(315, 235, Gosu::Color::BLUE, 325, 255, Gosu::Color::BLUE, 335, 235, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 9
        Gosu.draw_triangle(325, 260, Gosu::Color::WHITE, 340, 230, Gosu::Color::WHITE, 355, 260, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(330, 255, Gosu::Color::BLUE, 340, 235, Gosu::Color::BLUE, 350, 255, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        # triangle 10
        Gosu.draw_triangle(340, 230, Gosu::Color::WHITE, 355, 260, Gosu::Color::WHITE, 370, 230, Gosu::Color::WHITE, ZOrder::TOP, mode = :default)
        Gosu.draw_triangle(345, 235, Gosu::Color::BLUE, 355, 255, Gosu::Color::BLUE, 365, 235, Gosu::Color::BLUE, ZOrder::TOP, mode = :default)
        
        outsideWheel = Gosu::Image.new(Circle.new(20))
        insideWheel = Gosu::Image.new(Circle.new(15))
        light = Gosu::Image.new(Circle.new(10))
        # front wheel
        outsideWheel.draw(220, 250, ZOrder::TOP, 1.0, 1.0, Gosu::Color::WHITE)
        insideWheel.draw(225, 255, ZOrder::TOP, 1.0, 1.0, Gosu::Color::BLACK)
        # rear wheel
        outsideWheel.draw(300, 250, ZOrder::TOP, 1.0, 1.0, Gosu::Color::WHITE)
        insideWheel.draw(305, 255, ZOrder::TOP, 1.0, 1.0, Gosu::Color::BLACK)
        # headlight
        light.draw(210, 210, ZOrder::TOP, 0.5, 1.0, Gosu::Color::YELLOW)
        # tailight
        light.draw(350, 210, ZOrder::TOP, 0.5, 1.0, Gosu::Color::RED)

    end
end

DemoWindow.new.show