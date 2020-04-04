using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace COIL100_ImageClassifier.Interfaces
{
    public interface IImageClassifier
    {
        Task<string> AnalyzeImage(MediaFile image);
    }
}
