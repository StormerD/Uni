; * * * * * * * * * * * * * * * * * * * * *
; Stage 2
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * * * * * * * *
; R0 = function arguments and return values
; R1 = function arguments and return values
; R2 = function arguments
; R3 = function arguments
; R4 = stores player name
; R5 = stores matchsticks number
; R6 = stores removed matchsticks number
; * * * * * * * * * * * * * * * * * * * * *

// initializes game functions
MatchsticksGame:
    PUSH {LR, R0, R2, R3}
    BL getGameInfo // retrieves game data
    MOV R4, R2 // stores player name return value in R4
    MOV R5, R3 // stores matchsticks number return value in R5
    POP {LR, R0, R2, R3}

    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL writeGameInfo // prints game data
    POP {LR, R0, R2, R3}

// functions that operate the game
gameFunctions:
    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameMessage
    POP {LR, R0, R2, R3}

    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL playerTurn
    MOV R6, R0 // stores removed matchsticks number in R6
    POP {LR, R0, R2, R3}

    PUSH {LR, R2, R3}
    MOV R2, R6 // passes removed matchsticks number via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameUpdate
    MOV R5, R3 // updates new matchsticks value in R5
    POP {LR, R2, R3}

    CMP R5, #0 // checks if matchsticks left
    BGT gameFunctions

finish:
    HALT

// function displays game over message
gameOver:
    MOV R0, #gameMsg5 // "Game Over!"
    STR R0, .WriteString
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    SUB R3, R3, R2 // removes selected matchsticks
    CMP R3, #0 // checks if matchsticks left
    PUSH {LR, R0}
    BEQ gameOver
    POP {LR, R0}
    RET

// function handles player turn
retry2:
    MOV R0, #errorMsg // "Please enter a valid number."
    STR R0, .WriteString
playerTurn:
    MOV R0, #gameMsg1 // "Player "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    MOV R0, #gameMsg4 // ", how many do you want to remove (1-7)? "
    STR R0, .WriteString
    LDR R0, .InputNum // save removed matchsticks number to R1
    STR R0, .WriteUnsignedNum
    CMP R0, R3
    BGT retry2
    CMP R0, #1
    BLT retry2
    CMP R0, #7
    BGT retry2
    RET

// function prints message of matchsticks left in the game to player
gameMessage:
    MOV R0, #gameMsg1 // "Player "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    MOV R0, #gameMsg2 // ", there are "
    STR R0, .WriteString
    STR R3, .WriteUnsignedNum // "{matchsticks number}"
    MOV R0, #gameMsg3 // " matchsticks remaining."
    STR R0, .WriteString
    RET

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
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)?"
gameMsg5: .ASCIZ "\nGame Over!"
errorMsg: .ASCIZ "\nPlease enter a valid number."
playerName: .BLOCK 20