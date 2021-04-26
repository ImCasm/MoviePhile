using Application.Common.Interfaces.Services;
using Moq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UnitTests.SearchMovie.Mocks
{
    public class HttpMovieClientServiceMock : Mock<IHttpMovieClientService>
    {
        public HttpMovieClientServiceMock()
        {
            SetupMethods();
        }

        public void SetupGetMoviesByName()
        {
            Setup(x => x.GetMoviesByName(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(Task.FromResult(MovieJson(true)));
        }

        public void SetupGetMovieById()
        {
            Setup(x => x.GetMovieById(It.IsAny<int>()))
                .Returns(Task.FromResult(MovieJson(false)));
        }

        public void SetupGetPopularMovies()
        {
            Setup(x => x.GetPopularMovies(It.IsAny<int>()))
                .Returns(Task.FromResult(MovieJson(true)));
        }

        private string MovieJson(bool isList)
        {
            StringBuilder stringMovieBuilder = new StringBuilder();

            if (isList)
            {
                stringMovieBuilder.Append("[");
            }

            stringMovieBuilder.Append("{\"adult\":false,\"backdrop_path\":\"/xjZUJR4M0arTC658KOkmsl9y5uP.jpg\",\"belongs_to_collection\":null,\"budget\":20000000,\"genres\":[{\"id\":14,\"name\":\"Fantasía\"},{\"id\":28,\"name\":\"Acción\"},{\"id\":12,\"name\":\"Aventura\"},{\"id\":878,\"name\":\"Ciencia ficción\"},{\"id\":53,\"name\":\"Suspense\"}],\"homepage\":\"https://www.mortalkombatmovie.net\",\"id\":460465,\"imdb_id\":\"tt0293429\",\"original_language\":\"en\",\"original_title\":\"Mortal Kombat\",\"overview\":\"Un boxeador fracasado descubre un secreto familiar que lo lleva a un torneo místico llamado Mortal Kombat donde se encuentra con un grupo de guerreros que luchan hasta la muerte para salvar los reinos del malvado hechicero Shang Tsung.\",\"popularity\":4901.131,\"poster_path\":\"/6K0RCDfP9ExbTcYgryaQHTGmET7.jpg\",\"production_companies\":[{\"id\":76907,\"logo_path\":\"/wChlWsVgwSd4ZWxTIm8PTEcaESz.png\",\"name\":\"Atomic Monster\",\"origin_country\":\"US\"},{\"id\":8000,\"logo_path\":\"/f8NwLg72BByt3eav7lX1lcJfe60.png\",\"name\":\"Broken Road Productions\",\"origin_country\":\"US\"},{\"id\":12,\"logo_path\":\"/iaYpEp3LQmb8AfAtmTvpqd4149c.png\",\"name\":\"New Line Cinema\",\"origin_country\":\"US\"},{\"id\":174,\"logo_path\":\"/ky0xOc5OrhzkZ1N6KyUxacfQsCk.png\",\"name\":\"Warner Bros. Pictures\",\"origin_country\":\"US\"},{\"id\":2806,\"logo_path\":\"/vxOhCbpsRBh10m6LZ3HyImTYpPY.png\",\"name\":\"South Australian Film Corporation\",\"origin_country\":\"AU\"},{\"id\":13033,\"logo_path\":null,\"name\":\"NetherRealm Studios\",\"origin_country\":\"\"}],\"production_countries\":[{\"iso_3166_1\":\"AU\",\"name\":\"Australia\"},{\"iso_3166_1\":\"US\",\"name\":\"United States of America\"}],\"release_date\":\"2021-04-07\",\"revenue\":28430000,\"runtime\":110,\"spoken_languages\":[{\"english_name\":\"English\",\"iso_639_1\":\"en\",\"name\":\"English\"},{\"english_name\":\"Japanese\",\"iso_639_1\":\"ja\",\"name\":\"日本語\"},{\"english_name\":\"Mandarin\",\"iso_639_1\":\"zh\",\"name\":\"普通话\"}],\"status\":\"Released\",\"tagline\":\"\",\"title\":\"Mortal Kombat\",\"video\":false,\"vote_average\":8.1,\"vote_count\":985}");

            if (isList)
            {
                stringMovieBuilder.Append("]");
            }

            return stringMovieBuilder.ToString();
        }

        private void SetupMethods()
        {
            SetupGetMovieById();
            SetupGetMoviesByName();
            SetupGetPopularMovies();
        }
    }
}
