require './gemstone'

def main()
    gemstone = Gemstone.new()

    gemstone.name = "Diamond"

    gemstone.polarising = Polarising_names[2]

    gemstone.hardness = 10

    # - - - - - - - - 

    puts(gemstone.name)
    puts(gemstone.polarising)
    puts(gemstone.hardness)
end

main()