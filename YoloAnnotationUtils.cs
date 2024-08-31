using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.Json;

public class YoloAnnotation : List<AnnotatedImage>
{
    public void AddNewAnnotatedImage(Bitmap image, List<AnnotatedObject> objects)
    {
        // Normalize coordinates and sizes
        foreach (var obj in objects)
        {
            obj.XCenter = obj.XCenter / image.Width;
            obj.YCenter = obj.YCenter / image.Height;
            obj.Width = obj.Width / image.Width;
            obj.Height = obj.Height / image.Height;
        }

        // Add new annotated image
        Add(new AnnotatedImage(image, objects));
    }

    public void SaveToPath(string path)
    {
        CheckPathAndCreate(path);
        CheckPathAndCreate(Path.Combine(path, "images"));
        CheckPathAndCreate(Path.Combine(path, "labels"));

        // Save images
        for (int i = 0; i < Count; i++)
        {
            var img = this[i];
            img.Image.Save(Path.Combine(path, "images", $"image{i}.jpg"));

            // Save labels
            using (var writer = new StreamWriter(Path.Combine(path, "labels", $"image{i}.txt")))
            {
                foreach (var obj in img.Objects)
                {
                    writer.WriteLine($"{obj.Class} {obj.XCenter.ToString("F17", CultureInfo.InvariantCulture)} {obj.YCenter.ToString("F17", CultureInfo.InvariantCulture)} {obj.Width.ToString("F17", CultureInfo.InvariantCulture)} {obj.Height.ToString("F17", CultureInfo.InvariantCulture)}");
                }
            }
        }

        // Create "classes.txt"
        var classes = this.SelectMany(img => img.Objects.Select(obj => obj.Class)).Distinct().ToList();
        File.WriteAllLines(Path.Combine(path, "classes.txt"), classes.Select(c => c.ToString()));

        // Create "coco8.yaml"
        var coco8Yaml = new
        {
            names = classes,
            path = path,
            nc = classes.Count,
            test = "images",
            train = "images",
            val = "images"
        };
        File.WriteAllText(Path.Combine(path, "coco8.yaml"), JsonSerializer.Serialize(coco8Yaml));

        // Create "notes.json"
        var notesJson = new
        {
            categories = classes.Select((c, i) => new { id = i, name = c }).ToList(),
            info = new
            {
                year = DateTime.Now.Year,
                version = "1.0",
                contributor = "Your Name" // Replace with your name
            }
        };
        File.WriteAllText(Path.Combine(path, "notes.json"), JsonSerializer.Serialize(notesJson));
    }

    private static void CheckPathAndCreate(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}


public class AnnotatedImage
{
    public AnnotatedImage(Bitmap image, List<AnnotatedObject> objects)
    {
        Image = image;
        Objects = objects;
    }

    public Bitmap Image { get; set; }
    public List<AnnotatedObject> Objects { get; set; }
}

public class AnnotatedObject
{
    public int Class { get; set; }
    public float XCenter { get; set; }
    public float YCenter { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
}
