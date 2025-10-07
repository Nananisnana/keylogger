# Konsol Tabanlı Metin Kaydedici ve E-posta Gönderici

Bu proje, C# ve .NET 8 kullanılarak geliştirilmiş basit bir konsol uygulamasıdır. Temel amacı, kullanıcı tarafından konsola girilen metni bir log dosyasına kaydetmek ve ardından bu dosyayı belirtilen bir e-posta adresine ek olarak göndermektir.

Bu proje, Nesne Tabanlı Programlama (OOP) dersi ödevi kapsamında, temel C# yeteneklerini ve modern .NET konfigürasyon yöntemlerini göstermek amacıyla oluşturulmuştur.

---

## 🚀 Çalışma Videosu

Bu projenin nasıl çalıştığını ve kodun temel mantığını anlatan videoya aşağıdaki linkten ulaşabilirsiniz:
▶️ **(https://youtu.be/vUFQWx8Z_qo)**
---

## ✨ Özellikler

- **Metin Girişi:** Kullanıcıdan konsol üzerinden metin girişi alır.
- **Dosyaya Kaydetme:** Girilen metni anlık olarak `log.txt` adında bir dosyaya kaydeder.
- **E-posta Gönderimi:** Kaydedilen `log.txt` dosyasını, SMTP üzerinden e-posta eki olarak gönderir.
- **Güvenli Konfigürasyon:** E-posta ve şifre gibi hassas bilgiler, kodun içine yazılmak yerine `appsettings.json` dosyası üzerinden güvenli bir şekilde yönetilir.
- **Temizlik:** E-posta başarıyla gönderildikten sonra oluşturulan `log.txt` dosyası otomatik olarak silinir.

---

## 🛠️ Kullanılan Teknolojiler

- **Dil:** C#
- **Platform:** .NET 8
- **Temel Kütüphaneler:**
  - `MailKit`: E-posta gönderim işlemleri için kullanılan modern ve güçlü bir kütüphane.
  - `Microsoft.Extensions.Configuration`: `appsettings.json` dosyasını okumak ve yönetmek için kullanılır.

---

## ⚙️ Kurulum ve Yapılandırma

Bu projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin.

### 1. Projeyi Klonlayın

```bash
git clone (https://github.com/Nananisnana/keylogger.git)
cd keylogger
```

### 2. NuGet Paketlerini Yükleyin

Projeyi Visual Studio ile açtığınızda, gerekli olan NuGet paketleri (`MailKit` vb.) otomatik olarak yüklenecektir.

### 3. `appsettings.json` Dosyasını Yapılandırın

Projenin çalışabilmesi için **en önemli adım** budur. Projenin ana dizininde **`appsettings.json`** adında bir dosya oluşturun ve içeriğini aşağıdaki şablona göre kendi bilgilerinizle doldurun.

> **Önemli:** Güvenlik nedeniyle bu dosya `.gitignore` aracılığıyla versiyon kontrolüne dahil edilmemiştir.

```json
{
  "EmailSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "SenderEmail": "gonderici@gmail.com",
    "SenderPassword": "google_uygulama_sifreniz",
    "ReceiverEmail": "alici@gmail.com"
  }
}
```

- **`Host`**: Kullandığınız e-posta servisinin SMTP sunucu adresi.
- **`Port`**: SMTP port numarası (Genellikle `587`).
- **`SenderEmail`**: E-postayı gönderecek olan hesabın adresi.
- **`SenderPassword`**: **Hesabınızın gerçek şifresi DEĞİL!** Gmail gibi servisler için oluşturmanız gereken 16 haneli **Uygulama Şifresi**.
- **`ReceiverEmail`**: E-postanın gönderileceği hedef adres.

---

## ▶️ Nasıl Kullanılır?

1.  Yukarıdaki yapılandırma adımlarını tamamladıktan sonra projeyi Visual Studio üzerinden çalıştırın (F5 veya Yeşil ▶ butonu).
2.  Uygulama sizden bir metin girmenizi isteyecektir.
3.  Metni girip `Enter`'a basın.
4.  Program, metni `log.txt` dosyasına kaydedecek, bu dosyayı e-posta olarak gönderecek ve işlem sonucunu size konsolda bildirecektir.

---