function nextt() {
    var user = document.getElementById("user").value;
    var verification_num = document.getElementById("verification_num").value;
    var newpwd = document.getElementById("newpwd").value;


    if (user == "" || verification_num == "" || newpwd == "") {
        alert("欄位不可為空");
        return false;
    }else{

    const formData = new FormData();
    formData.append("user_account", user);
    formData.append("user_authcode", verification_num);
    formData.append("new_Pwd", newpwd);
    axios
      .post("https://localhost:7105/api/ForgetPwd/verify_cord", formData, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        console.log("Response:", response.data);
        alert("密碼已變更，請重新登入");
        window.location.href = "./login.html"
      })
      .catch((error) => {
        console.error("Error:", error);
      });
      
    }
}

var send = document.getElementById("send");
send.addEventListener("click", send1);
function send1() {
    var user = document.getElementById("user").value;
        if(user != ""){
            var email = document.getElementById("user").value;
            //JSON 檔案網址
            let url = `https://localhost:7105/api/ForgetPwd/ForgetPwd/Send_email?Account=${email}`;
            let data = [];
            // step 1 - 取得資料
            (function getData() {
              axios
                .get(url).then(function (response) {
                  // 檢查
                  console.log(response.data);
                  // 將取得資料帶入空陣列data中
                  data = response.data;
                  console.log(data.length);
                  alert(response.data);
                })
                .catch((error) => {
                  console.log(error);
                  alert("error:錯誤");
                });
            })();
        }else if(user == ""){
            alert("請先輸入帳號(email)");
        }
}
