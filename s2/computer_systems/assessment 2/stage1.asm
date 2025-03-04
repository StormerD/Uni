; * * * * * * * * * * * * * * * * * * * * *
; Stage 1
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * * * * * * * *
; R0 = function arguments and return values
; R1 = function arguments and return values
; R2 = function arguments
; R3 = function arguments
; R4 = stores player name
; R5 = stores matchsticks number
; * * * * * * * * * * * * * * * * * * * * *

// initializes game functions
MatchsticksGame:
    PUSH {LR, R0, R2, R3}
    BL getGameInfo // retrieves game data
    MOV R4, R2 // stores player name return value in R5
    MOV R5, R3 // stores matchsticks number return value in R6
    POP {LR, R0, R2, R3}
    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R0
    MOV R3, R5 // passes matchstick number via R1
    BL writeGameInfo // prints game data
    POP {LR, R0, R2, R3}

finish:
    HALT

// function retrieves and stores player data
getGameInfo:
    PUSH {LR}
    BL getPlayerInfo
    POP {LR}
    PUSH {LR}
    BL getMatchstickInfo
    POP {LR}
    RET

// function retrieves and stores player info
getPlayerInfo:
    MOV R0, #getName // "Please enter your name: "
    STR R0, .WriteString
    MOV R2, #playerName
    STR R2, .ReadString // save player name to R5
    STR R2, .WriteString
    RET

// function retrieves and stores matchstick info
retry:
    MOV R1, #errorMsg // "Please enter a valid number."
    STR R1, .WriteString
getMatchstickInfo:
    MOV R0, #getMatchsticks // "How many matchsticks (10-100)? "
    STR R0, .WriteString
    LDR R3, .InputNum // save matchstick number to R3
    STR R3, .WriteUnsignedNum
    CMP R3, #10
    BLT retry
    CMP R3, #100
    BGT retry
    RET

// function prints player and matchstick info to display
writeGameInfo:
    PUSH {LR}
    BL writePlayerInfo
    POP {LR}
    PUSH {LR}
    BL writeMatchstickInfo
    POP {LR}
    RET

// function prints player name to display
writePlayerInfo:
    MOV R0, #writePlayerMsg // "Player 1 is "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    RET

// function prints matchstick number to display
writeMatchstickInfo:
    MOV R0, #writeMatchsticksMsg // "How many matchsticks (10-100)? "
    STR R0, .WriteString
    STR R3, .WriteUnsignedNum // "{matchsticks number}"
    RET

; * * * * * * * * * * * * * * * * * * * * *
.Align 256
getName: .ASCIZ "\nPlease enter your name: "
getMatchsticks: .ASCIZ "\nHow many matchsticks (10-100)? " 
writePlayerMsg: .ASCIZ "\nPlayer 1 is "
writeMatchsticksMsg: .ASCIZ "\nMatchsticks: "
gameMsg1: .ASCIZ "\nPlayer "
gameMsg2: .ASCIZ ", there are "
gameMsg3: .ASCIZ " matchsticks remaining."
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)? "
gameMsg5: .ASCIZ "\nGame Over"
errorMsg: .ASCIZ "\nPlease enter a valid number."
playerName: .BLOCK 20