; * * * * * * * * * * * * * * 
; Stage: 2
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * 
; R0 = stores notifications
; R1 = used to print message stored in R0
; R2 = stores matchsticks removed every round
; R3 = stores player name
; R4 = stores matchsticks number
; * * * * * * * * * * * * * * 

// initializes all functions to operare game
MatchsticksGame:
    BL getGameInfo // retrieves game data
    BL writeGameInfo // prints game data

gameFunctions:
    BL gameMessage // displays game state messages
    BL playerTurn // handles player turn
    BL gameUpdate // updates game state
    BL checkContinue // loops game if not over

finish:
    HALT
    
// function checks if the game is not over and loops it back
checkContinue:
    PUSH {LR, R0}
    CMP R9, #0 // checks if game is over
    BGT gameFunctions
    POP {LR, R0}
    RET

// function displays game over message
gameOver:
    PUSH {LR, R0}
    MOV R0, #gameMsg5 // "Game Over"
    BL displayMessage
    POP {LR, R0}
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    PUSH {LR, R0}
    SUB R4, R4, R2 // removes selected matchsticks
    CMP R4, #0 // checks if matchsticks left
    BEQ gameOver
    POP {LR, R0}
    RET

// function handles player turn
playerTurn:
    PUSH {LR, R0}
    BL continue2
retry2:
    MOV R0, #errorMsg // "Please enter a valid number."
    BL displayMessage
continue2:
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R3, .WriteString // "{player name}"
    MOV R0, #gameMsg4 // ", how many do you want to remove (1-7)?"
    BL displayMessage
    LDR R2, .InputNum // save removed matchsticks value to R2
    STR R2, .WriteUnsignedNum
    CMP R2, R4
    BGT retry2
    CMP R2, #1
    BLT retry2
    CMP R2, #7
    BGT retry2
    POP {LR, R0}
    RET

// function prints message of matchsticks left in the game to player
gameMessage:
    PUSH {LR, R0}
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R3, .WriteString // "{player name}"
    MOV R0, #gameMsg2 // ", there are "
    BL displayMessage
    STR R4, .WriteUnsignedNum // "{matchsticks left}"
    MOV R0, #gameMsg3 // " matchsticks remaining."
    BL displayMessage
    POP {LR, R0}
    RET

// function retrieves and stores player and matchstick info
getGameInfo:
    PUSH {LR}
    BL getPlayerInfo
    BL getMatchstickInfo
    POP {LR}
    RET

// function retrieves and stores player info
getPlayerInfo:
    PUSH {LR, R0}
    MOV R0, #getName // "Please enter your name: "
    BL displayMessage
    MOV R3, #playerName
    STR R3, .ReadString // save player name to R3
    STR R3, .WriteString
    POP {LR, R0}
    RET

// function retrieves and stores matchstick info
getMatchstickInfo:
    PUSH {LR, R0}
    BL continue1
retry1:
    MOV R0, #errorMsg // "Please enter a valid number."
    BL displayMessage
continue1:
    MOV R0, #getMatchsticks // "How many matchsticks (10-100)? "
    BL displayMessage
    LDR R4, .InputNum // save matchstick number to R4
    STR R4, .WriteUnsignedNum
    CMP R4, #10
    BLT retry1
    CMP R4, #100
    BGT retry1
    POP {LR, R0}
    RET

// function prints player and matchstick info
writeGameInfo:
    PUSH {LR}
    BL writePlayerInfo
    BL writeMatchstickInfo
    POP {LR}
    RET

// function prints player name
writePlayerInfo: 
    PUSH {LR, R0, R3}
    MOV R0, #writePlayerMsg
    BL displayMessage
    STR R3, .WriteString
    POP {LR, R0, R3}
    RET

// function prints matchstick number
writeMatchstickInfo:
    PUSH {LR, R0, R4}
    MOV R0, #writeMatchsticksMsg
    BL displayMessage
    STR R4, .WriteUnsignedNum
    POP {LR, R0, R4}
    RET

// function prints messages stored to R0
displayMessage:
    MOV R1, R0
    STR R1, .WriteString
    RET

; - - - - - - - - -
.Align 256
getName: .ASCIZ "Please enter your name: "
getMatchsticks: .ASCIZ "\nHow many matchsticks (10-100)? " 
writePlayerMsg: .ASCIZ "\nPlayer 1 is "
writeMatchsticksMsg: .ASCIZ "\nMatchsticks: "
gameMsg1: .ASCIZ "\nPlayer "
gameMsg2: .ASCIZ ", there are "
gameMsg3: .ASCIZ " matchsticks remaining."
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)?"
gameMsg5: .ASCIZ "\nGame Over"
errorMsg: .ASCIZ "\nPlease enter a valid number."
playerName: .BLOCK 20