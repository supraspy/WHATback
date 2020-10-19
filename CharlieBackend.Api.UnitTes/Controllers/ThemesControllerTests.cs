﻿using CharlieBackend.Api.Controllers;
using System.Collections.Generic;
using CharlieBackend.Business.Services.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using CharlieBackend.Core.Models.Theme;

namespace CharlieBackend.Api.UnitTest.Controllers
{
	public class ThemesControllerTests
	{
		[Fact]
		public void GetAllThemesTestAsync()
		{
			//Arrange

			var themeServiceMock = new Mock<IThemeService>();
			themeServiceMock.Setup(repo => repo.GetAllThemesAsync()).Returns(GetThemes);
			ThemesController controller = new ThemesController(themeServiceMock.Object);

			//Act

			var GetResult = controller.GetAllThemes();
			var themesObjectResult = GetResult.Result.Result as ObjectResult;

			//Assert

			Assert.NotNull(themesObjectResult);
		}

		public async Task<IList<ThemeModel>> GetThemes()
		{
			List<ThemeModel> ThemesL = new List<ThemeModel>
			{
				new ThemeModel { Id = 12, Name = "Tema1" }
			};
			return ThemesL;
		}
	}
}