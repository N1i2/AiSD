#include<iostream>
#include<ctime>

using namespace std;

int main()
{
	srand(time(NULL));
	int student{}, * assecc{};

	cout << "enter number student:\t";
	cin >> student;
	if (!cin)
	{
		cout << "error\n";
		return 0;
	}
	else if (student <= 0)
	{
		cout << "error\n";
		return 0;
	}

	assecc = new int[student];

	for (int i = 0; i < student; i++)
	{
		assecc[i] = rand() % 10 + 1;
		cout << assecc[i] << '\n';
	}

	for (int i = 0; i < student; i++)
	{
		for (int j = 0; j < student - i - 1; j++)
		{
			if (assecc[j] < assecc[j + 1])
				swap(assecc[j], assecc[j + 1]);
		}
	}
	cout << "\n\n";
	for (int i = 0; i < student; i++)
		cout << assecc[i] << '\n';

	int result{}, check{assecc[0]};

	for (int i = 0, u{1}; i < student; i++)
	{
		if (assecc[i] != check)
		{
			check = assecc[i];
			u++;
		}
		if (u == 4)
		{
			result = i;
			break;
		}
	}

	if (result == student)
		cout << "\nall winer\n";
	else if(result==0)
		cout << "\nall winer\n";
	else
	cout << "Winer:\t"<<result;
	delete[] assecc;
	return 0;
}