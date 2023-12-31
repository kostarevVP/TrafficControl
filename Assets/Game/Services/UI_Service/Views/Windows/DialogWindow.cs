﻿using UnityEngine;
using UnityEngine.UI;

namespace WKosArch.UI_Service.Views.Windows
{
	public abstract class DialogWindow<TWindowViewModel> : Window<TWindowViewModel> where TWindowViewModel : WindowViewModel
	{
		[Space]
		[SerializeField] protected Button _btnClose;
		[SerializeField] protected Button _btnCloseAlt;

		public override void Subscribe()
		{
			base.Subscribe();

			if (_btnClose != null)
			{
				_btnClose.onClick.AddListener(OnCloseButtonClick);
			}

			if (_btnCloseAlt != null)
			{
				_btnCloseAlt.onClick.AddListener(OnCloseButtonClick);
			}
		}

		public override void Unsubscribe()
		{
			base.Unsubscribe();
			
			if (_btnClose != null)
			{
				_btnClose.onClick.RemoveListener(OnCloseButtonClick);
			}

			if (_btnCloseAlt != null)
			{
				_btnCloseAlt.onClick.RemoveListener(OnCloseButtonClick);
			}
		}

		protected virtual void OnCloseButtonClick()
		{
			_ = Hide();
		}
	}
}