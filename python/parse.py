import argparse

parser = argparse.ArgumentParser(description='Insert a new blog entry')

parser.add_argument('-t', '--title', action='store')
parser.add_argument('-l', '--link', action='store')

args = parser.parse_args()

print(args.title)
print(args.link)
