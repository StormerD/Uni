module Genre
    POP, CLASSIC, JAZZ, ROCK = *1..4
end

$genre_names = ['Null', 'Pop', 'Classic', 'Jazz', 'Rock']

def main()
    i = 1
    while i < 5
        puts(i.to_s() + " " + $genre_names[i])
        i += 1
    end
end 

main()