#include<iostream>
#include<Windows.h>
#include<iomanip>

using namespace std;

struct hashTable
{
	int number{};
	string name{};
	hashTable* next{ NULL }, * prev{ NULL };
};

struct helpTable
{
	int number{};
	string name{};
	helpTable* next;
};

int creat(int, hashTable**, int);
void show(hashTable**, int);
hashTable* locate(int, hashTable*);
void dele(int, hashTable**);
int sort(hashTable**, int, int*, string*);
void clearr(hashTable**, int);
int creat2(helpTable*, hashTable**, int);

void main()
{
	setlocale(LC_ALL, "ru");
	HANDLE color{ GetStdHandle(STD_OUTPUT_HANDLE) };

	int numb{}, n{ 7 }, schet{}, var{};
	hashTable** start{ new hashTable * [n] };

	for (int i{}; i < n; i++)
		start[i] = NULL;

	while (true)
	{
		SetConsoleTextAttribute(color, 15);
		system("cls");
		cout << "Сделайте выбор\n";
		cout << "1 - добавить несколько номеров\n";
		cout << "2 - добавить номер\n";
		cout << "3 - удолить номер\n";
		cout << "4 - найти по номеру\n";
		cout << "5 - вывести все\n";
		cout << "6 - конец\n";
		cin >> var;

		switch (var)
		{
		case 1:
		{
			int col{};
			cout << "Введие количество номеров:\t";
			cin >> col;
			for (int i{}; i < col; i++)
			{
				cout << i + 1 << ") введите номер телефона:\t";
				cin >> numb;
				if (!cin || numb < 1)
				{
					cout << "Такого не может быть\n";
					cin.clear();
					cin.ignore(100, '\n');

					continue;
				}
				try
				{
					schet = creat(numb, &start[numb % n], schet);
				}
				catch (const std::exception& el)
				{
					SetConsoleTextAttribute(color, 4);
					cout << el.what() << '\n';
					SetConsoleTextAttribute(color, 15);
					i--;
				}
			}
		}
		break;

		case 2:
			while (true)
			{
				cout << "Введите номер телефона:\t";
				cin >> numb;
				if (!cin || numb < 1)
				{
					cout << "Такого не может быть\n";
					cin.clear();
					cin.ignore(100, '\n');
					continue;
				}
				try
				{
					schet = creat(numb, &start[numb % n], schet);
				}
				catch (const std::exception& el)
				{
					SetConsoleTextAttribute(color, 4);
					cout << el.what() << '\n';
				}
				break;
			}
			break;

		case 3:
			cout << "Введите номер который надо удалить:\t";
			cin >> numb;
			if (!cin || numb < 1)
			{
				cout << "Такого не может быть\n";
				cin.clear();
				cin.ignore(100, '\n');
				break;
			}
			try
			{
				dele(numb, &start[numb % n]);
			}
			catch (const std::exception& el)
			{
				SetConsoleTextAttribute(color, 4);
				cout << el.what() << '\n';
				cin.clear();
				cin.ignore(100, '\n');
			}
			break;

		case 4:
			cout << "Введите искомый номер:\t";
			cin >> numb;
			if (!cin || numb < 1)
			{
				cout << "Такого номера точно нет\n";
				cin.clear();
				cin.ignore(100, '\n');
				break;
			}
			try
			{
				hashTable* help{ locate(numb, start[numb % n]) };
				cout << "Этот номер принадлежит:\t" << help->name << '\n';
			}
			catch (const std::exception& el)
			{
				SetConsoleTextAttribute(color, 4);
				cout << el.what() << '\n';
			}
			break;

		case 5:
			try
			{
				show(start, n);
			}
			catch (const std::exception& el)
			{
				SetConsoleTextAttribute(color, 4);
				cout << el.what() << '\n';
			}
			break;

		case 6:
			cout << "Конец\n";
			SetConsoleTextAttribute(color, 0);
			exit(0);
			break;

		default:
			cout << "Такого варианта нет\n";
			cin.clear();
			cin.ignore(100, '\n');
			break;
		}
		if (var == 1 || var == 2)
		{
			if (schet >= (double)(n * 0.7))
			{
				hashTable* q{};
				helpTable* go{ NULL }, * gg{ NULL };
				schet = 0;

				for (int i = 0; i < n; i++)
				{
					if (start[i] != NULL)
					{
						q = start[i];
						while (q != NULL)
						{
							helpTable* c{ new helpTable };

							c->number = q->number;
							c->name = q->name;
							c->next = NULL;

							if (go == NULL)
							{
								go = gg = c;
							}
							else
							{
								gg->next = c;
								gg = c;
							}

							q = q->prev;
						}
					}
				}

				clearr(start, n);

				n *= 2;
				start = new hashTable * [n];
				for (int i = 0; i < n; i++)
					start[i] = NULL;

				while (go != NULL)
				{
					gg = go;
					go = go->next;
					schet = creat2(gg, start, schet);
					delete gg;
				}
			}
		}
		SetConsoleTextAttribute(color, 0);
		system("pause");

	}

	clearr(start, n);
	delete[] start;
}

int creat(int numb, hashTable** use, int st)
{
	hashTable* q{ nullptr };
	string name{};
	q = new hashTable;

	q->number = numb;

	if (*use != NULL)
	{
		hashTable* c{ *use };

		while (c != NULL)
		{
			if (c->number == q->number)
			{
				delete q;
				throw exception("Такой номер уже был");
			}
			c = c->prev;
		}
		(**use).next = q;
		q->prev = (*use);
		q->next = NULL;
	}
	else
	{
		q->next = q->prev = NULL;
		st++;
	}

	*use = q;

	cout << "Введите фамилию чей это номер:\t";
	cin >> name;
	(*q).name += name;
	cout << "Введите имя владельца номера:\t";

	cin >> name;
	(*q).name += ' ';
	(*q).name += name;

	cout << "Успешно добавлено\n";

	return st;
}

void dele(int numb, hashTable** use)
{
	int var{};
	hashTable* del{ *use };
	while (del != NULL && del->number != numb)
		del = del->prev;

	if (del == NULL)
		throw exception("Ткой номер не найден");

	cout << "Это номер " << del->name << '\n';
	cout << "Если вы все еще уверены что хотите удолить нажмите на 1:\t";
	cin >> var;

	if (var != 1)
		throw exception("Удоление номера отменено");

	if (del == *use)
	{
		*use = del->prev;
		if (*use != NULL)
			(**use).next = NULL;
		else
			*use = NULL;
	}
	else
	{
		if (del->prev == NULL)
			(del->next)->prev = NULL;
		else
		{
			(del->next)->prev = del->prev;
			(del->prev)->next = del->next;
		}
	}

	delete del;
	cout << "Номер удолен\n";
}

void show(hashTable** start, int n)
{
	int schet{};
	hashTable* q{};
	cout << "Имена\t\t\t\t" << "Номера\n" << setw(50) << setfill('=') << '=' << '\n';
	for (int i = 0; i < n; i++)
	{
		if (start[i] != NULL)
		{
			q = start[i];
			while (q != NULL)
			{
				cout << ++schet << ")" << q->name << '(';
				cout.width(20);
				cout << ") \"" << q->number << "\"\n";
				q = q->prev;
			}
		}
	}
	if (schet == 0)
		throw exception("Книжка пуста");
}

hashTable* locate(int numb, hashTable* use)
{
	hashTable* c{ use };
	while (c != NULL && c->number != numb)
		c = c->prev;

	if (c == NULL)
		throw exception("Ткой номер не найден");

	return c;
}

void clearr(hashTable** use, int n)
{
	int schet{};
	hashTable* q{}, * m{};

	for (int i = 0; i < n; i++)
	{
		if (use[i] != NULL)
		{
			q = use[i];
			while (q != NULL)
			{
				m = q;
				q = q->prev;
				delete m;
			}
		}
	}
}

int creat2(helpTable* go, hashTable** use, int st)
{
	hashTable* q{ nullptr };
	q = new hashTable;

	q->number = go->number;
	q->name = go->name;

	if (*use != NULL)
	{
		hashTable* c{ *use };

		while (c != NULL)
		{
			c = c->prev;
		}
		(**use).next = q;
		q->prev = (*use);
		q->next = NULL;
	}
	else
	{
		q->next = q->prev = NULL;
		st++;
	}

	*use = q;

	return st;
}