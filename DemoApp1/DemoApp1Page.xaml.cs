using Xamarin.Forms;

namespace DemoApp1
{
	public partial class DemoApp1Page : ContentPage
	{
		// Brain

		private int _number;
		private bool _isPrime;

		public int number
		{
			get
			{
				return _number;
			}
			set
			{
				_number = value;
				isPrime = checkPrime(_number);
			}
		}

		public bool isPrime
		{
			get
			{
				return _isPrime;
			}
			set
			{
				_isPrime = value;
				updateUI();
			}
		}

		bool checkPrime(int x)
		{
			if (x <= 1)
				return false; 
			else if (x <= 3)
				return true;

			for (int i = 3; i < x; i++)
				if (x % i == 0)
					return false;
			
			return true;
		}

		// Controller

		public DemoApp1Page()
		{
			InitializeComponent();
			pushUIElements();
		}

		void CheckButton_Clicked(object sender, System.EventArgs e)
		{
			try
			{
				number = int.Parse(textField.Text);
			}
			catch
			{
				number = -1;
			}
		}

		// UI

		StackLayout view;
		Label statusLabel;
		Entry textField;
		Button checkButton;

		void updateUI()
		{
			string type;
			checkButton.TextColor = Color.White;

			if (isPrime == false)
			{
				type = "NEPRIM";
				view.BackgroundColor = Color.Red;
			}
			else
			{
				type = "PRIM";
				view.BackgroundColor = Color.Green;
			}

			statusLabel.Text = "Numar " + type;
			statusLabel.TextColor = Color.White;

			DisplayAlert(
				"Rezultat",
				"Numarul " + number + " este:\n" + type,
				"Inchide"
			);
		}

		void pushUIElements()
		{
			view = new StackLayout
			{
				MinimumHeightRequest = 340
			};

			// Status Label
			statusLabel = new Label
			{
				Text = "STATUS",
				FontAttributes = FontAttributes.Bold,
				Margin = 50,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center
			};
			view.Children.Add(statusLabel);

			// Check Button
			checkButton = new Button
			{
				Text = "Verifica",
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				Margin = 8,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			checkButton.Clicked += CheckButton_Clicked;

			// Text Field
			textField = new Entry
			{
				Placeholder = "Numarul este...",
				WidthRequest = 280,
				Keyboard = Keyboard.Numeric,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};


			// Group with TextField and Check Button
			StackLayout centeredGroup = new StackLayout
			{
				MinimumHeightRequest = 0,
				MinimumWidthRequest = 0,
				Margin = 100,
				HorizontalOptions = LayoutOptions.Center,

				Children = {
					textField,
					checkButton
				}
			};

			view.Children.Add(centeredGroup);
			Content = view;
		}
	}
}
