# 4chanImageDownloader
Downloads images a full thread at a time from either 4chan or 4channel using ASP.NET.

## Getting Started
Launch the application, put in you're thread number and board letter, click download and a zip file will be created with the images shortly. After that download you're images!

## Developing

To begin developing on the project follow these commands.

```shell
git clone https://github.com/Mshriver2/4chanDownloader.git
cd 4chanDownloader/
```

## Features
* Multi Thread Download (**Coming Soon**)
* Allow image conversion (**Coming Soon**)
* Download in multiple formats gif, jpg, png, webm, ect (**Coming Soon**)

## Roadmap
* ~~parse the html string with the Html Agility Pack library extracting image filenames~~
* store the image file names into an array
* download the files to server using array and for loop
* remove the 's' from the end of image url's in array
* zip images using thread name
* provide download button for user to retrieve images
* allow user to select all file types, or specific types
