linked file
require './input_functions'

# define Genre module
module Genre
  POP, CLASSIC, JAZZ, ROCK = *1..4
end

# define Genre_names global variable
Genre_names = ['Null', 'POP', 'Classic', 'Jazz', 'Rock']

# define Album class
class Album
  attr_accessor :title, :artist, :genre
end

# asks user for album info and stores it in a class
def read_album()
  puts("Enter Album")
  # album name
  album_title = read_string("Enter album name:")
  # artist name
  album_artist = read_string("Enter artist name:")
  # genre
  album_genre = read_integer_in_range("Enter Genre between 1 - 4: ", "1", "4")

  # stores album info in new Album class -> album
  album = Album.new()
  album.title = album_title
  album.artist = album_artist
  album.genre = album_genre

  # returns album class
  return album
end

# prints info from album class
def print_album(album)
  puts('Album information is: ')
  puts(album.title)
  puts(album.artist)
	puts('Genre is ' + album.genre.to_s)
  puts Genre_names[album.genre.to_i] # we will cover this in Week 6!
end

# gets album info from user input then prints it to the terminal
def main()
	album = read_album()
	print_album(album)
end

# initializes main if the linked file exists
main() if __FILE__ == $0