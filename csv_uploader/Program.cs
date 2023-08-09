using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

var data = JsonSerializer.Deserialize<BalanceChangeModel[]>(File.ReadAllText("data.json"));
var walletId = "c62e0022-7141-478a-ac4c-088f5f2f1cbf";
var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik5UazROVGhEUmpFM1F6QkVOelExTnpFNU16VXlPREpDUmpNM01UQkdOVEZGTkRnMlFrSTFSUSJ9.eyJpc3MiOiJodHRwczovL2Rldi05c2MxMnU4bi5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NjJmY2E4ZTkyNGVhZjc1ZjVlZjA3MmZmIiwiYXVkIjpbIndhbGxldG1hbmFnZXItYXBpIiwiaHR0cHM6Ly9kZXYtOXNjMTJ1OG4uYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTY5MTU0OTQ3NSwiZXhwIjoxNjkxNjM1ODc1LCJhenAiOiJWMnBTMWFvUkdWNWxUNXhjeXk1c0N5dUdPNnNpRE5pTCIsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUifQ.axfAStrmQq_qrrQ57nS3puTQcKqIKTKy1oyvBqB7PMgRdWnObB4ZD_KVZ6L8HV9NPwBPKAHDQqMCM4laPANjRHpD_99UelhroyIcAF0gRtw4zyWauGmRj0-nKDmT7IwZCSO5d5B_VPCJhh1DlBJKm6vOzqBVsKNaQgqm7ZW4N4_x2uujwSFr3SQIvXDU9k26oQRq-tpxAWEXnT4qGIsZzKPtb2KAlfeRn4aGcKmR-UwtAAzW-wK5SUuHnVHuK6eP_Eud-tXqRkchyo0Cx4p7vyejrK2z6WZ_wdQ0-5zgyxXqxFWgzaOVu5OaicIuPsRH16iBMc2BGZewslrvICSZXQ";
foreach (var d in data)
{
    HttpClient http = new HttpClient();
    http.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    await http.PostAsJsonAsync($"https://wm.minhnguyenle.work/api/wallet/{walletId}/balance", d);
}

class BalanceChangeModel
{
    public bool ChangeType { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}