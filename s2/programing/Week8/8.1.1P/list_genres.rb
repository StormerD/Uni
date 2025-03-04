
# put the genre names array here:
$genres = ["Pop", "Classic", "Jazz", "Rock"]

def print_genres(genres)
    i = 0
    while i < genres.length()
        list_number = i + 1
        puts(list_number.to_s + " " + genres[i])
        i += 1
    end
end
def main()
    print_genres($genres)
end

main()