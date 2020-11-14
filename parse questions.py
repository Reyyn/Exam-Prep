# get file contents
with open("CEH Questions Version 10-2.txt") as f:
	data = f.readlines()

# clean out whitespace
data = [x.strip() for x in data]
data = [x for x in data if x]

question = {}
questions = []
answer = ''
for line in data:
	if line.startswith("NEW"):
		questions.append(question)
		question = {}
		q = line.replace("NEW QUESTION ",'')
		question["id"] = q
	elif (len(line.strip()) == 2):
		answer = line[:1]
		question[answer] = ''
	elif ("Exam Topic" in line):
		if line.startswith("-"):
			line.replace("-",'')
		t = line.split(')', 1)[0].replace("(Exam Topic ",'')
		question["topic"] = t
		q = line.split(')', 1)[1].strip()
		question["question"] = q
	elif line.startswith("Answer"):
		a = line.replace("Answer: ",'')
		question["answer"] = a
	elif ("Explanation:" in line):
		answer = "explanation"
	else:
		if (line == "-"):
			pass
		else:
			question[answer] = line

del questions[0]

with open("ceh_questions2.xml", "w") as f:
	f.write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n")
	f.write("<questions>\n")

	for q in questions:
		f.write(f"\t<question id={q.get('id', '')} topic={q.get('topic','')} answer={q.get('answer','')}>\n")
		f.write(f"\t\t<text>{q.get('question','')}</text>\n")
		for key in q.keys():
			if len(key) == 1:
				f.write(f"\t\t<{key}>{q[key]}</{key}>\n")
		f.write(f"\t\t<explanation>{q.get('explanation','')}</explanation>\n")
		f.write("\t</question>\n")

	f.write("</questions>")
