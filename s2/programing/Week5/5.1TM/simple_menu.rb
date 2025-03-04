# linked file
require './input_functions'

# sub-if menu 2
# display albums menu
def display_albums
  begin
    puts 'Display Albums Menu:'
    puts '1 Display All Albums'
    puts '2 Display Albums by Genre'
    puts '3 Return to Main Menu'
    choice = read_integer_in_range("Please enter your choice:", 1, 3)
    case choice
    when 1
      read_string("You selected Display All Albums. Press enter to continue")
    when 2
      read_string("You selected Display Albums By Genre. Press enter to continue")
    when 3
      finished = true
    else
      puts "Please select again"
    end
  end until finished
end

# sub-if menu 1
def load_albums
  read_string("You selected Load Albums. Press enter to continue")
end

# creates menu for user to navigate
def main()
  finished = false
  begin
    puts 'Main Menu:'
    puts '1 Load Albums'
    puts '2 Display Albums'
    puts '3 Exit'
    choice = read_integer_in_range("Please enter your choice:", 1, 3)
    case choice
    when 1
      load_albums
    when 2
      display_albums
    when 3
      finished = true
    else
      puts "Please select again"
    end
  end until finished
end

# initializes main if the linked file exists
main() if __FILE__ == $0