#include<iostream>

using namespace std;
int numb{};

struct test
{
	char skoba{};
	test* next{};
};

struct elem
{
	char simvl{};
	elem* next{};
};

test* filling();
int check(test**);

void main()
{
	setlocale(LC_ALL, "ru");

	cout << "Введите строку (что бы прекратить запись введите \".\")\n";

	test* start{ filling() };

	if (start != NULL)
		if (numb % 2 == 1)
			cout << "Скобки расставлены не правильно\n";
		else
		check(&start) ? cout << "Ошибок в скобках нет\n" : cout << "Скобки расставлены не правильно\n";
	else
		cout << "Скобок вообще нет\n";
}

test* filling()
{
	test* start{ NULL },* q{};
	char sim{};

	cin >> sim;
	while (sim!='.')
	{
		if (sim == '(' || sim == '{' || sim == '[' || sim == ')' || sim == '}' || sim == ']')
		{
			numb++;
			q = new test;
			q->skoba = sim;
			if (start == NULL)
				q->next = NULL;
			else
				q->next = start;
			start = q;
		}

		cin >> sim;
	}

	return start;
}

int check(test** s)
{
	test* del{ *s };
	elem* start{ NULL }, * w{};
	int itog{};
	char sim{};

	while (del)
	{
		*s = (*s)->next;
		sim = del->skoba;

		if (itog < 0)
			return 0;

		if (sim == ')' || sim == '}' || sim == ']')
		{
			itog++;
			w = new elem;
			
			if (sim == ')')
				w->simvl = '(';
			else if (sim == '}')
				w->simvl = '{';
			else if (sim == ']')
				w->simvl = '[';

			if (start == NULL)
				w->next = NULL;
			else
				w->next = start;
			start = w;
		}
		else
		{
			if (sim != start->simvl)
				return 0;
			if (start == NULL)
				return 0;

			itog--;
			w = start;
			start = start->next;
			delete w;
		}

		delete del;
		del = *s;
	}

	if (itog == 0)
		return 1;
	return 0;
}