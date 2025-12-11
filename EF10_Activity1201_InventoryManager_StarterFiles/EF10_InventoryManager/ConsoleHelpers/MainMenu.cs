using AutoMapper;
using EF10_InventoryDBLibrary;
using EF10_InventoryManager.Features.CRUD;
using EF10_InventoryManager.Features.LINQandProjections;
using EF10_InventoryManager.Features.SortingFilteringPaging;
using EF10_InventoryManager.Features.UnitOfWork;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.ConsoleHelpers;

public class MainMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;
    private readonly IMapper _mapper;

    private readonly CreateOperationsMenu _createOperationsMenu;
    private readonly DeleteOperationsMenu _deleteOperationsMenu;
    private readonly ReadOperationsMenu _readOperationsMenu;
    private readonly UpdateOperationsMenu _updateOperationsMenu;
    private readonly ProceduresMenu _proceduresMenu;
    private readonly FunctionsMenu _functionsMenu;
    private readonly ViewsMenu _viewsMenu;
    private readonly DemoQueriesMenu _demoQueriesMenu;
    private readonly SortingFilteringPagingActivityMenu _sortingFilteringPagingActivityMenu;
    private readonly ChapterNineDemos _chapterNineDemos;
    private readonly Activity0901 _activity0901;
    private readonly UnitOfWorkMenu _unitOfWorkMenu;

    private readonly IItemService _itemService;
    private readonly ICategoryService _categoryService;
    private readonly IContributorService _contributorService;
    private readonly IGenreService _genreService; //added for Chapter 11 activities
    private readonly IParserService _parserService; //1102
    public MainMenu(InventoryDbContext context, int lineLength, IMapper mapper
                        , IItemService itemService, ICategoryService categoryService
                        , IContributorService contributorService, IGenreService genreService
                        , IParserService parserService)
    {
        _db = context;
        _lineLength = lineLength;
        _mapper = mapper;
        _itemService = itemService;
        _categoryService = categoryService;
        _contributorService = contributorService;
        _genreService = genreService;
        _parserService = parserService;
        _createOperationsMenu = new CreateOperationsMenu(_lineLength, _itemService, _categoryService, _contributorService);  //changed to use services 11-1
        _readOperationsMenu = new ReadOperationsMenu(_lineLength, _itemService, _categoryService, _contributorService); //changed to use services 11-1
        _updateOperationsMenu = new UpdateOperationsMenu(_lineLength, _itemService, _genreService, _categoryService); //changed to use services 11-1
        _deleteOperationsMenu = new DeleteOperationsMenu(_lineLength, _itemService, _categoryService); //changed to use services 11-1

        _proceduresMenu = new ProceduresMenu(_db, _lineLength);
        _functionsMenu = new FunctionsMenu(_db, _lineLength);
        _viewsMenu = new ViewsMenu(_db, _lineLength);
        _demoQueriesMenu = new DemoQueriesMenu(_db, _lineLength);
        _sortingFilteringPagingActivityMenu = new SortingFilteringPagingActivityMenu(_db, _lineLength);
        _chapterNineDemos = new ChapterNineDemos(_db, _lineLength);
        _activity0901 = new Activity0901(_db, _lineLength, _mapper);

        _unitOfWorkMenu = new UnitOfWorkMenu(_lineLength, _itemService, _categoryService, _contributorService, _genreService, _parserService);
    }

    public async Task ShowAsync()
    {
        bool shouldContinue = true;
        while (shouldContinue)
        {
            Console.Clear();

            List<string> menuOptions = GetMenuOptions();

            var menuText = MenuGenerator.GenerateMenu("Main Menu", "Please select an operation", menuOptions, 40);

            // Show menu and get user choice
            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            try
            {
                shouldContinue = await HandleMenuChoiceAsync(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        switch (choice)
        {
            case 1:
                await _readOperationsMenu.ShowAsync();
                break;
            case 2:
                await _createOperationsMenu.ShowAsync();
                break;
            case 3:
                await _updateOperationsMenu.ShowAsync();
                break;
            case 4:
                await _deleteOperationsMenu.ShowAsync();
                break;
            case 5:
                await _proceduresMenu.ShowAsync();
                break;
            case 6:
                await _functionsMenu.ShowAsync();
                break;
            case 7:
                await _viewsMenu.ShowAsync();
                break;
            case 8:
                await _demoQueriesMenu.ShowAsync();
                break;
            case 9:
                await _sortingFilteringPagingActivityMenu.ShowAsync();
                break;
            case 10:
                await _chapterNineDemos.ShowAsync();
                break;
            case 11:
                await _activity0901.ShowAsync();
                break;
            case 12:
                await _unitOfWorkMenu.ShowAsync();
                break;
            default:
                return false;
        }
        return true;

    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Read Operations",
            "Create Operations",
            "Update Operations",
            "Delete Operations",
            "Stored Procedures",
            "Functions",
            "Views",
            "Demo Queries (Efficient Queries)",
            "Sorting, Filtering, and Paging",
            "Chapter Nine Demos (LINQ and Projections)",
            "Chapter Nine Activity (LINQ/Projections/AutoMapper)",
            "Chapter Eleven Unit of Work",
            "Exit"
        };
    }
}
