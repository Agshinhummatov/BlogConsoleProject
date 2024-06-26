using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Constants
{
    public class ResponseMessages
    {
        // General messages
        public const string NotFound = "Data not found.";
        public const string ExistMessage = "Data already exists.";
        public const string StringMessage = "Field cannot be empty.";
        public const string StringCharacterMessage = "Field cannot contain characters.";

        // Success messages
        public const string SuccessMessage = "Operation successful!";
        public const string DeleteSuccessMessage = "Blog successfully deleted.";
        public const string BlogCreated = "Blog created successfully.";
        public const string BlogUpdated = "Blog updated successfully.";

        // Error messages
        public const string TryAgainMessage = "Please try again.";
        public const string NoBlogsFound = "No blogs found.";
        public const string BlogNotFound = "Blog not found.";
        public const string NoBlogsAvailable = "No blogs available to delete.";
        public const string NoBlogsMatchingSearch = "No blogs found matching the search text.";
        public const string NoBlogsToUpdate = "No blogs available to update.";
        public const string InvalidBlogIdFormat = "Invalid blog Id format.";

        // Input validation messages
        public const string InvalidAuthorSelection = "Invalid author selection.";
        public const string InvalidTagSelection = "Invalid tag selection.";
        public const string TagNameEmpty = "Tag name cannot be empty.";
        public const string InvalidBlogId = "Invalid blog Id.";
        public const string AuthorNameEmpty = "Author name cannot be empty.";
        public const string AuthorNameExists = "Author with this name already exists.";
        public const string TagNameExists = "Tag with this name already exists.";

        // Console prompts
        public const string AddBlogTitle = "Please add blog title:";
        public const string AddBlogContent = "Please add blog content:";
        public const string EnterBlogId = "Please enter the Id of the blog you want to view:";
        public const string SelectBlogToDelete = "Select a blog to delete:";
        public const string EnterBlogIdToDelete = "Please enter the Id of the blog you want to delete:";
        public const string EnterSearchText = "Please add search text:";
        public const string SelectBlogToUpdate = "Select a blog to update:";
        public const string EnterBlogIdToUpdate = "Please enter the Id of the blog you want to update:";
        public const string AddBlogTitleToUpdate = "Please add blog title (leave empty to keep existing):";
        public const string AddBlogContentToUpdate = "Please add blog content (leave empty to keep existing):";
        public const string SelectOrCreateAuthorToUpdate = "Please select or create an author:";
        public const string SelectOrCreateAuthorChoice = "Enter the number of the author to select, or type 'create' to create a new author:";
        public const string EnterNewAuthorName = "Enter new author's name:";
        public const string SelectOrCreateTagsToUpdate = "Please select or create tags (you can select multiple tags, type 'done' when finished):";
        public const string SelectOrCreateTagChoiceToUpdate = "Enter the number of the tag to select, or type 'create' to create a new tag, or 'done' to finish:";
        public const string EnterNewTagName = "Enter new tag's name:";

        //Console options

        public const string OptionsMessage ="Blog options : \n 1 - Create Blog, \n 2 - Get all Blogs, \n 3 - Delete blog, \n 4 - Search blog,\n 5 - Get blog by id, \n 6 - Update blog";
        public const string SelectOption = "Please select one option :";
        public const string CorrecFormatOption = "Please add correct format option";
        public const string CorrectOption = "Please add correct option";

    }
}
