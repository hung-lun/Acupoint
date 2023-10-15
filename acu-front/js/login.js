function login() {
  var user = document.getElementById("user").value;
  var pwd = document.getElementById("pwd").value;

  if (user == "" || pwd == "") {
    alert("欄位不得為空");
    return false;
  } else if ((user != "") & (pwd != "")) {
    const formData = new FormData();
    formData.append("user_account", user);
    formData.append("user_pwd", pwd);
    axios
      .post("https://localhost:7105/api/User/Login", formData, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        console.log("Response:", response);
        console.log("資料:", response.data.user.user_level);
        if (
          (response.status === 200) &
          (response.data.user.user_level == true)
        ) {
          // alert("即將進入使用者畫面");
          console.log(response.data.encodedJwt); //token
          localStorage.setItem("login", response.data.encodedJwt); //設定名為login的localStoragea存入token資料
          var login = localStorage.getItem("login"); //抓名為login的localStoragea裡的資料
          var user = document.getElementById("user").value; //抓帳號輸入框的value
          localStorage.setItem("user", user); //設定名為user的localStoragea存入帳號輸入框的value資料
          var user = localStorage.getItem("user"); //抓名為user的localStoragea存入帳號輸入框的value資料
          console.log(user);
          localStorage.setItem("user_id", response.data.user.user_id); //設定名為login的localStoragea存入token資料
          var user_id = localStorage.getItem("user_id"); //抓名為login的localStoragea裡的資料
          console.log(user_id);
          window.location.href = "front-index.html"; //跳轉到會員首頁
        } else if (
          (response.status === 200) &
          (response.data.user.user_level == false)
        ) {
          // alert("即將進入管理員畫面");
          console.log(response.data.encodedJwt);
          localStorage.setItem("login", response.data.encodedJwt);
          var login = localStorage.getItem("login");
          console.log(login);
          var user = document.getElementById("user").value;
          localStorage.setItem("admin", user);
          var admin = localStorage.getItem("admin");
          console.log(admin);
          window.location.href = "../acu-back/back-diagnosis.html";
        }
      })
      .catch((error) => {
        console.error("Error:", error);
        if (error.response.status === 400) {
          alert(error.response.data);
          return false;
        }
      });
  }
}
