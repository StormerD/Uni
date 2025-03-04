; * * * * * * * * * * * * * * 
; Stage: 1
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * 
; R0 = stores notifications
; R1 = used to print message stored in R0
; R2 = stores player name
; R3 = stores matchsticks number
; * * * * * * * * * * * * * * 

// initializes game functions
MatchsticksGame:
    BL getGameInfo // retrieves game data
    BL writeGameInfo // prints game data

finish:
    HALT

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
    MOV R2, #playerName
    STR R2, .ReadString // save player name to R2
    STR R2, .WriteString
    POP {LR, R0}
    RET

// function retrieves and stores matchstick info
getMatchstickInfo:
    PUSH {LR, R0}
    BL continue
retry1:
    MOV R0, #errorMsg // "Please enter a valid number."
    BL displayMessage
continue:
    MOV R0, #getMatchsticks // "How many matchsticks (10-100)? "
    BL displayMessage
    LDR R3, .InputNum // save matchstick number to R3
    STR R3, .WriteUnsignedNum
    CMP R3, #10
    BLT retry1
    CMP R3, #100
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
    PUSH {LR, R0, R8}
    MOV R0, #writePlayerMsg
    BL displayMessage
    STR R8, .WriteString
    POP {LR, R0, R8}
    RET

// function prints matchstick number
writeMatchstickInfo:
    PUSH {LR, R0, R9}
    MOV R0, #writeMatchsticksMsg
    BL displayMessage
    STR R9, .WriteUnsignedNum
    POP {LR, R0, R9}
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
errorMsg: .ASCIZ "\nPlease enter a valid number."
playerName: .BLOCK 20