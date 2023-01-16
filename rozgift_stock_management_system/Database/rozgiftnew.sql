-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 16 Oca 2023, 20:01:44
-- Sunucu sürümü: 5.7.36
-- PHP Sürümü: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `rozgiftnew`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `firma`
--

DROP TABLE IF EXISTS `firma`;
CREATE TABLE IF NOT EXISTS `firma` (
  `firKodu` int(10) NOT NULL AUTO_INCREMENT,
  `firAdi` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `firTel` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `firAdr` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`firKodu`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `firma`
--

INSERT INTO `firma` (`firKodu`, `firAdi`, `firTel`, `firAdr`) VALUES
(2, 'Lego', '000000', 'aaaaaaaa');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategori`
--

DROP TABLE IF EXISTS `kategori`;
CREATE TABLE IF NOT EXISTS `kategori` (
  `katId` int(50) NOT NULL AUTO_INCREMENT,
  `katAdi` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`katId`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `kategori`
--

INSERT INTO `kategori` (`katId`, `katAdi`) VALUES
(2, 'saat'),
(3, 'oyuncak'),
(4, 'çiçek'),
(5, 'bardak'),
(8, 'kolye'),
(9, 'anahtarlik'),
(10, 'Gözlük'),
(11, 'Cüzdan'),
(12, 'Parfüm'),
(13, 'Kitap'),
(14, 'Yüzük');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kulltb`
--

DROP TABLE IF EXISTS `kulltb`;
CREATE TABLE IF NOT EXISTS `kulltb` (
  `kull_ID` int(11) NOT NULL AUTO_INCREMENT,
  `kullAdi` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kullSifre` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kullMail` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`kull_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `kulltb`
--

INSERT INTO `kulltb` (`kull_ID`, `kullAdi`, `kullSifre`, `kullMail`) VALUES
(1, 'admin', 'admin123', 'testkull@test.com'),
(2, 'user', 'user123', 'testkul2@test.com'),
(3, 'deneme', '123', 'deneme@deneme');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri`
--

DROP TABLE IF EXISTS `musteri`;
CREATE TABLE IF NOT EXISTS `musteri` (
  `musId` int(100) NOT NULL AUTO_INCREMENT,
  `musAdi` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `musTel` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `musAdr` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `musCins` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`musId`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `musteri`
--

INSERT INTO `musteri` (`musId`, `musAdi`, `musTel`, `musAdr`, `musCins`) VALUES
(7, 'Seyma Nur Dogan', '12345678901', 'Burada Adres BIlgileri Bulunmakta', 'Kadin');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `siparis`
--

DROP TABLE IF EXISTS `siparis`;
CREATE TABLE IF NOT EXISTS `siparis` (
  `siparis_num` int(50) NOT NULL AUTO_INCREMENT,
  `mus_ID` int(50) NOT NULL,
  `kull_ID` int(50) NOT NULL,
  `Tarih` date NOT NULL,
  `Tutar` int(50) NOT NULL,
  PRIMARY KEY (`siparis_num`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `siparis`
--

INSERT INTO `siparis` (`siparis_num`, `mus_ID`, `kull_ID`, `Tarih`, `Tutar`) VALUES
(1, 7, 0, '2023-01-12', 60);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

DROP TABLE IF EXISTS `urunler`;
CREATE TABLE IF NOT EXISTS `urunler` (
  `urKodu` int(100) NOT NULL AUTO_INCREMENT,
  `urAdi` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `urKategori` int(100) NOT NULL,
  `urMiktar` int(100) NOT NULL,
  `urAlfiyat` int(100) NOT NULL,
  `urSatFiyat` int(100) NOT NULL,
  `urTarih` date NOT NULL,
  `urSup` int(100) NOT NULL,
  `urKazanc` int(100) NOT NULL,
  PRIMARY KEY (`urKodu`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`urKodu`, `urAdi`, `urKategori`, `urMiktar`, `urAlfiyat`, `urSatFiyat`, `urTarih`, `urSup`, `urKazanc`) VALUES
(1, 'bardak', 0, 33, 43, 333, '2023-01-12', 18, 290),
(2, 'kolye', 2, 3, 34, 35, '2023-01-12', 14, 1),
(7, 'kolye', 2, 2, 20, 30, '2023-01-14', 20, 10),
(8, 'lego', 5, 30, 30, 50, '2023-01-06', 2, 20),
(9, 'bardak', 4, 332, 43, 333, '2023-01-12', 2, 290);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
