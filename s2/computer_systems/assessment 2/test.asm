    MOV R0, #.PixelScreen
    MOV R1, #0xe21335
    MOV R2, #10 // number of matchsticks
    MOV R4, #264 // position of matchstick pixel
    MOV R5, #0 // current matchstick id
    BL drawMatchsticks
finish:
    HALT
drawMatchsticks:
    PUSH {LR, R3}
    MOV R3, #0 // number of matchsticks drawn
continueDraw:
    BL setLine0
    ADD R3, R3, #1
    CMP R3, R2
    BNE continueDraw
    BEQ finish
setLine0:
    PUSH {LR, R0, R1, R2, R4, R5}
    CMP R3, #10
    BGT setLine1
    BL checkPos

setLine1:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #20
    BGT setLine2
    BL checkPos

setLine2:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #30
    BGT setLine3
    BL checkPos

setLine3:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #40
    BGT setLine4
    BL checkPos

setLine4:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #50
    BGT setLine3
    BL checkPos

setLine5:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #60
    BGT setLine3
    BL checkPos

setLine6:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #70
    BGT setLine3
    BL checkPos

setLine7:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #80
    BGT setLine3
    BL checkPos

setLine8:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    CMP R3, #90
    BGT setLine3
    BL checkPos

setLine9:
    ADD R4, R4, #1280 // move pixel to new line
    ADD R5, R5, #10
    BL checkPos

checkPos:
    CMP R5, R3
    BEQ draw
    BNE setPos
setPos:
    ADD R4, R4, #24
    ADD R5, R5, #1
    B checkPos
draw:
    STR R1, [R0, R4]
    POP {LR, R0, R1, R2, R4, R5}
    RET
