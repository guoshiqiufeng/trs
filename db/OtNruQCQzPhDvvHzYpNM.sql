-- phpMyAdmin SQL Dump
-- http://www.phpmyadmin.net
--
-- 生成日期: 2017 年 02 月 17 日 17:28

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `OtNruQCQzPhDvvHzYpNM`
--

-- --------------------------------------------------------

--
-- 表的结构 `car`
--

CREATE TABLE IF NOT EXISTS `car` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `user_id` bigint(20) NOT NULL,
  `startDate` varchar(10) NOT NULL,
  `startTime` varchar(16) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `car_number` varchar(20) NOT NULL,
  `car_name` varchar(20) DEFAULT NULL,
  `car_sum` int(11) NOT NULL,
  `car_destination` varchar(50) NOT NULL,
  `car_origin` varchar(50) NOT NULL,
  `type` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=15 ;

--
-- 转存表中的数据 `car`
--

INSERT INTO `car` (`id`, `user_id`, `startDate`, `startTime`, `phone`, `car_number`, `car_name`, `car_sum`, `car_destination`, `car_origin`, `type`) VALUES
(4, 2, '2016-4-18', '21:10', '13332663632', '', '', 3, '常州市', '安顺市', 0),
(6, 3, '2016-4-13', '21:42', '13222112343', '', '', 1, '白银市', '博州', 0),
(8, 3, '2016-11-29', '20:41', '1231231', '', '', 1, '安顺市', '安康市', 0),
(9, 2, '2016-4-29', '02:08', '123', '', '', 4, '安顺市', '安顺市', 0),
(10, 2, '2016-5-11', '18:19', '18242536526', '1部', '', 1, '阿克苏', '安庆市', 1),
(11, 2, '2016-4-30', '12:01', '18672849328', '875240', '', 1, '安康市', '白银市', 1),
(12, 2, '2016-4-30', '10:07', '18086669163', '', '', 2, '安阳市', '安康市', 0),
(14, 3, '2016-5-6', '04:25', '13888888888', '鄂A1234', '', 1, '安康市', '昌吉州', 1);

-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `nick_name` varchar(50) NOT NULL,
  `uimg` varchar(50) DEFAULT NULL,
  `usex` int(11) DEFAULT NULL,
  `password` varchar(50) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  `user_type` int(11) NOT NULL,
  `token` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`id`, `username`, `nick_name`, `uimg`, `usex`, `password`, `phone`, `email`, `user_type`, `token`) VALUES
(2, 'admin', 'admin', '/images/user/ba9fbd88906265eee5ab0bbbed03e9ba.jpg', 1, 'e10adc3949ba59abbe56e057f20f883e', '', '', 0, 'ba9fbd88906265eee5ab0bbbed03e9ba'),
(3, 'test1', '测试账号', '/images/user/0d716500ed3ac492da87b3383cb2ba2d.jpg', 0, 'e10adc3949ba59abbe56e057f20f883e', '13222112343', 'test@test.com', 0, '0d716500ed3ac492da87b3383cb2ba2d'),
(4, 'test2', 'test2', NULL, 1, 'e10adc3949ba59abbe56e057f20f883e', '', '', 0, '24953e8bece59b6b95b249e4a8641fd9'),
(5, 'abcde', 'abcde', '/images/user/94a8cead077036e7ac91b3095f9255ab.jpg', 0, 'e10adc3949ba59abbe56e057f20f883e', '', '', 0, '94a8cead077036e7ac91b3095f9255ab');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
