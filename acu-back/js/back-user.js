var logout1 = document.getElementById("logout");
logout1.addEventListener("click", logout);
    function logout() {
        if (confirm('確認要登出嗎？') == true) {
            window.location.href = "../acu-front/login.html";
            localStorage.clear();
        } else {

        }
    }
    

    const url = "https://localhost:7105/api/User/B_All";
    let data = [];
    fetch(url) //判斷api有沒有資料
      .then((response) => {
        if (response.ok) {
          //如果api有資料就執行以下程式碼顯示資料
  
          // step 1 - 取得資料
          (function getData() {
            axios.get(url).then(function (response) {
              // 檢查
              console.log(response.data);
              // 將取得資料帶入空陣列data中
              data = response.data;
              title(data);
            });
          })();
  
          function title(arr) {
            // 抓取欄位
            const p_title = document.querySelector(".table_content");
            let str = "";
            // 將資料存入
            arr.forEach(function (data) {
                if(`${data.user_level}` == "false"){
                    var level = "<a style='color:red'>管理員</a>";
                    var start = "--";
                }else if(`${data.user_level}` == "true"){
                    var level = "使用者";
                    if(`${data.user_start}` == 0){
                        var start = "<input id='update"+`${data.user_id}`+"' type='button' class='start-btn mouse' value='啟用'>";
                    }else if(`${data.user_start}` == 1){
                        var start = "<input id='update"+`${data.user_id}`+"' type='button' class='stop-btn mouse' value='停用'>";
                    }
                }
                

            aaa = `
                <tr align="center">
                <th>帳號</th>
                <th>姓名</th>
                <th>權限</th>
                <th>功能</th>
            </tr>
                `
            str += `
            <tr align="center">
            <td>${data.user_account}</td>
            <td>${data.user_name}</td>
            <td>${level}</td>
            <td>${start}</td>
        </tr>
              `;
            });
            p_title.innerHTML = aaa+str;


      }}});