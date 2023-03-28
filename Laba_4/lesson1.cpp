#include<iostream>
#include<ctime>

using namespace std;

int main()
{
	srand(time(NULL));

	int numb{},* goods;
	cout << "enter the number:\t";
	cin >> numb;
	if (!cin)
	{
		cout << "error\n";
		cin.clear();
		cin.ignore(100, '\n');
		return 0;
	}
	else if (numb <= 0)
	{
		cout << "error\n";
		return 0;
	}

	goods = new int[numb];
	for (int i = 0; i < numb; i++)
	{
		goods[i] = rand() % 20 + 1;
		cout << goods[i] << '\n';
	}

	for (int i = 0; i < numb; i++)
	{
		for (int j = i; j < numb - 1; j++)
		{
			if (j % 2 == 0)
			{
				if (goods[j] < goods[j + 1])
					swap(goods[j], goods[j + 1]);
			}
			else
				if (goods[j] > goods[j + 1])
					swap(goods[j], goods[j + 1]);
		}
	}
	cout << "\n\n";
	for (int i = 0; i < numb; i++)
		cout << goods[i] << "\n";

	int max{};

	for (int i = 0; i < numb; i+=2)
		max += goods[i];

	cout << "summ:\t" << max;

	cout << "\n\nEnd\n";
	return 0;
}