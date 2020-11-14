import re

with open("ceh_questions2.xml") as f:
	data = f.readlines()

new_data = []

for line in data:
	if re.search(r"\<question id=\d+ topic=-?\d* answer=\w*\>", line):
		s1 = re.split('=| ', line)
		new_line = f"\t<question id='{s1[2]}' topic='{s1[4][-1]}' answer='{s1[6].strip()[:-1]}'>\n"
		new_data.append(new_line)
	else:
		new_data.append(line)

with open("ceh_questions2.1.xml", 'w') as f:
	f.writelines(new_data)
