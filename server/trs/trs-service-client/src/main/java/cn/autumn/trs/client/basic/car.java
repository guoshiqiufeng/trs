package cn.autumn.trs.client.basic;

public class car {
    private Long id;

    private Long userId;

    private String startdate;

    private String starttime;

    private String phone;

    private String carNumber;

    private String carName;

    private Integer carSum;

    private String carDestination;

    private String carOrigin;

    private Integer type;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Long getUserId() {
        return userId;
    }

    public void setUserId(Long userId) {
        this.userId = userId;
    }

    public String getStartdate() {
        return startdate;
    }

    public void setStartdate(String startdate) {
        this.startdate = startdate == null ? null : startdate.trim();
    }

    public String getStarttime() {
        return starttime;
    }

    public void setStarttime(String starttime) {
        this.starttime = starttime == null ? null : starttime.trim();
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone == null ? null : phone.trim();
    }

    public String getCarNumber() {
        return carNumber;
    }

    public void setCarNumber(String carNumber) {
        this.carNumber = carNumber == null ? null : carNumber.trim();
    }

    public String getCarName() {
        return carName;
    }

    public void setCarName(String carName) {
        this.carName = carName == null ? null : carName.trim();
    }

    public Integer getCarSum() {
        return carSum;
    }

    public void setCarSum(Integer carSum) {
        this.carSum = carSum;
    }

    public String getCarDestination() {
        return carDestination;
    }

    public void setCarDestination(String carDestination) {
        this.carDestination = carDestination == null ? null : carDestination.trim();
    }

    public String getCarOrigin() {
        return carOrigin;
    }

    public void setCarOrigin(String carOrigin) {
        this.carOrigin = carOrigin == null ? null : carOrigin.trim();
    }

    public Integer getType() {
        return type;
    }

    public void setType(Integer type) {
        this.type = type;
    }
}