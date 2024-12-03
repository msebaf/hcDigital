package request;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import modelo.LoginRequest;
import modelo.Paciente;
import modelo.Profesional;
import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.POST;
import retrofit2.http.Path;

public class ApiClient {

   //private static final String PATH = "http://192.168.56.1:5000/"; /*ip para emulador*/
    private static final String PATH = "http://192.168.1.100:5000/"; /*Telefono red de arriba*/

    private static EndPointHcDigital endPointHcDigital;

    public static EndPointHcDigital getEndPointHcDigital() {

        Gson gson = new GsonBuilder().setLenient().create();

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(PATH)
                .addConverterFactory(GsonConverterFactory.create(gson))
                .build();

        endPointHcDigital = retrofit.create(EndPointHcDigital.class);

        return endPointHcDigital;

    }

    public interface EndPointHcDigital {

        @POST("Profesional/login")
        Call<String> login(@Body LoginRequest loginRequest);

        @GET("/profesionales")
        Call<Profesional> profesionales(@Header(("Authorization")) String token);

        @GET("profesional/n/{Dni}")
        Call<Profesional> getProfesional(@Header(("Authorization")) String token, @Path("Dni") String Dni);

        @GET("Paciente/n/{Dni}")
        Call<Paciente> getPaciente(@Header(("Authorization")) String token, @Path("Dni") String Dni);

        @POST("Paciente")
        Call<Paciente> nuevoPaciente(@Header(("Authorization")) String token, @Body Paciente paciente);
    }
}
