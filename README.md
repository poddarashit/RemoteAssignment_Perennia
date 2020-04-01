# RemoteAssignment_Perennia
Task name: Bill Splitter

Description:
Several friends planned to go camping every year. The group agrees in advance to share expenses equally, but it is not practical to have them share every expense as it occurs. Each individual in the group will pay for particular things, like food, drinks, supplies, the campsite, parking, etc. After the camping trip, each person’s expenses are tallied and money is exchanged so that the net cost to each is the same. This task is tedious and time-consuming. The objective of this application is to compute the payable amount for each person going in camping.

Input
Standard input will contain the information for several camping trips.
The information for each trip consists of a line containing a positive integer, n, the number of peopling participating in the camping trip, followed by n groups of inputs, one for each camping participant. Each group consists of a line containing a positive integer, p, the number of receipts/charges for that participant, followed by p lines of input, each containing the amount, in dollars and cents, for each charge by that camping participant. A single line containing 0 follows the information for the last camping trip.

Output
For each camping trip, output one line per participant indicating how much he/she must pay or be paid rounded to the nearest cent. If the participant owes money to the group, then the amount is positive. If the participant should collect money from the group, then the amount is negative. Negative amounts should be denoted by enclosing the amount in brackets. Each trip should be separated by a blank line.

Example input
3
2
30.00
12.00
4
15.00
15.01
9.00
3.01
3
5.00
74.00
4.00
2
2
12.01
6.00
2
8.95
7.75
0

Output for Example Input
($13.673)
($13.653)
$27.327
$0.655
($0.655)

Note:
Input file is at the location \BillSplitters\BillSplitters\bin\Debug\netcoreapp3.1
Output file will be generated at the same location as of Input file location.

Sample input file - march_expenses.txt
Sample Output file - march_expenses.txt.out

While running pass argument along with BillSplitters.exe

If the input file is not mentioned in the above mentioned path then input full input file path.
