# Programming Test 2 Part 4

# linked file
require './t2_p4_gemstone'

# defines record
def main()
    # creates new Gemstone class -> gemstone
    gemstone = Gemstone.new
    # define gemstone name as "Diamond"
    gemstone.name = "Diamond"
    # define gemstone polarising as "Isotropic"
    gemstone.polarising = Polarising_names[2]
    # define gemstone hardness as 10
    gemstone.hardness = 10

    # print gemstone attributes
    puts(gemstone.name)
    puts(gemstone.polarising)
    puts(gemstone.hardness)
end

# initializes program if linked file exists
main() if __FILE__ == $0