
import tkinter as tk
from tkinter import *
from tkinter import scrolledtext 

# Python3 Program for Bad Character Heuristic of Boyer Moore String Matching Algorithm 

NO_OF_CHARS = 256

def badCharHeuristic(string, size):
	'''
	The preprocessing function for Boyer Moore's bad character heuristic
    '''

	# Initialize all occurrence as -1
	badChar = [-1]*NO_OF_CHARS

	# Fill the actual value of last occurrence
	for i in range(size):
		badChar[ord(string[i])] = i

	# return initialized list
	return badChar

def search(txt, pat):
	'''
	A pattern searching function that uses Bad Character Heuristic of Boyer Moore Algorithm
	'''
 
	m = len(pat)
	n = len(txt)

	indices = []
	# create the bad character list by calling the preprocessing function badCharHeuristic()for given pattern
	badChar = badCharHeuristic(pat, m) 

	# s is shift of the pattern with respect to text
	s = 0
	while(s <= n-m):
		j = m-1

		# Keep reducing index j of pattern while characters of pattern and text are matching at this shift s
		while j >= 0 and pat[j] == txt[s+j]:
			j -= 1

		# If the pattern is present at current shift, then index j will become -1 after the above loop
		if j<0:
			indices.append(s)

			''' 
				Shift the pattern so that the next character in text aligns with the last occurrence of it in pattern.
				The condition s+m < n is necessary for the case when pattern occurs at the end of text
			'''
			s += (m-badChar[ord(txt[s+m])] if s+m<n else 1)
		else:
			'''
			Shift the pattern so that the bad character in text aligns with the last occurrence of it in pattern. The
			max function is used to make sure that we get a positive shift. We may get a negative shift if the last occurrence
			of bad character in pattern is on the right side of the current character.
			'''
			s += max(1, j-badChar[ord(txt[s+j])])
	return indices

''' 
This code is contributed by Atul Kumar, found at https://www.geeksforgeeks.org/boyer-moore-algorithm-for-pattern-searching/
Modified to fit the GUI, all code below this point was produced by the challenger.
'''

def clear_all():
    
    # clears stext boxes when clear button is pressed
    txt.delete('1.0', END)
    txt2.delete(0, tk.END)
    
    # clears display labels and outputs
    lblSearch.configure(text = '')
    lbl.configure(text = '')
    clear_output(labels_to_clear)
    
    #focuses cursor back on main text box
    txt.focus_set()
    
def submit():
    
    # removes any labels that were not cleared by user before clicking submit
    if labels_to_clear:
        clear_output(labels_to_clear)
    
    # retreives input
    all_text = txt.get("1.0", tk.END)
    pattern = txt2.get()
    
	# calling the boyer algorithm
    found_ind = search(all_text, pattern)
    
    # creates labels and grids them to a specific area    
    lbl.configure(text = 'Results found as highlighted: ', font = ('Helvetica 12'))
    lbl.grid(row = 9, column = 0, padx = 5, pady =5)
    
    # starting columns and rows for this display
    row = 2
    column = 1
    
    #initializing needed variables
    plength = len(pattern)
    i = 0
     
    while i < len(all_text):
    
        if i in found_ind:
            
            #loops over found pattern
            for _ in (range(plength)):
                #creates highlighted label
                label = tk.Label(root, text= all_text[i], font=("Helvetica 10"),  bg='yellow') 
                
                #column configuration
                if column % 30 == 0:
                    column += 1
                    
                # grids label to screen
                label.grid(row = row, column = column % 30)
                
                # adds to list of labels to be removed after
                labels_to_clear.append(label)
                
                # column is shifted
                column += 1
                
                # i is incremented
                i+= 1
             
        else:
            
			# will not be highlighted, printed normally
            label = tk.Label(root, text= all_text[i], font=("Helvetica 10"))
            i += 1
            label.grid(row=row, column= column % 30)
            labels_to_clear.append(label)
            column += 1
        
        # condition so to not print in column 0 and to skip row after 30 characters
        if column % 30 == 0:
            row += 1
            column += 1

# function to clear screen
def clear_output(labels_to_clear):
    for label in labels_to_clear:
        label.destroy()
    labels_to_clear.clear()


if __name__ == "__main__":

    root = Tk()
    frame = Frame(root)
    
    # create a label widget as a child to the root
    root.title('String Matching Machine')
    root.geometry('1200x350')

    # Prompt the user to input text and pattern
    lbl = Label(root, text = 'Enter your text: ', font = 'Helvetica 12')
    lbl.grid(row = 1, column = 0, padx = 5, pady = 5)

    txt = scrolledtext.ScrolledText(root, wrap=tk.WORD, width=50, height=4, font=("Helvetica 12")) 
    txt.grid(row = 2, column = 0, rowspan = 3, padx = 15, pady = 2)

    # placing cursor in text area 
    txt.focus()

    uSearch = Label(root, text = 'Enter a pattern to be found within your text: ', font = 'Helvetica 12')
    uSearch.grid(row = 5, column = 0, pady = 2)
    
    # accepting entry
    txt2 = Entry(root, width = 40)
    txt2.grid(row = 6, column = 0, pady = 2)

    # creating button
    btn = Button(root, text = 'Submit', fg = 'red', command = submit)
    btn.grid(row = 7, column = 0, pady = 2)

    # creating clear button
    btn2 = Button(root, text = 'Clear', bg = 'red', fg = 'black', command = clear_all)
    btn2.grid(row = 8, column = 0, pady = 2)

    # intializing labels and list
    lblSearch = Label(root)
    lblSearch.grid(row = 9, column = 0, pady = 2)
    lbl = Label()

    labels_to_clear = []
    
    # running main window
    root.mainloop()
    