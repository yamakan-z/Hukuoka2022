using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public abstract class SpriteNumbers<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private string _Text = "";

    [SerializeField]
    protected List<T> _Components = new List<T>();

    public int Length => _Components.Count;

    [SerializeField]
    private Color _Color = Color.white;

    [SerializeField]
    private LayoutType _LayoutType = LayoutType.Center;

    [SerializeField]
    private float _Span = 1.0F;

    [SerializeField]
    private List<Sprite> _Sprites = new List<Sprite>();

    [SerializeField]
    private RuntimeAnimatorController _AnimationController = null;

    [SerializeField]
    [Range(0.1F, 5.0F)]
    private float _AnimationSpeed = 1.0F;

    [SerializeField]
    [Range(0.0F, 1.0F)]
    private float _AnimationDelaySeconds = 0.14F;

    [SerializeField]
    [Range(0.0F, 5.0F)]
    private float _DestoryDelaySeconds = 0.8F;

    public enum LayoutType : int
    {
        Center = 1,
        Left = 2,
        Right = 3,
    }

    #region Unity Editor
#if UNITY_EDITOR

    private bool _IsExecuted = false;

    public void Start()
    {
        if (!string.IsNullOrEmpty(_Text) && _Components.Count() <= 0)
        {
            SetText(_Text, true);
        }
    }

    private void OnValidate()
    {
        // Hierarchy 上でアクティブであるか
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        // 起動時に実行される OnValidate であるか
        if (EditorApplication.isPlayingOrWillChangePlaymode && !_IsExecuted)
        {
            _IsExecuted = true;
            return;
        }
        
        // Sprite のリストの例外用の初期化（データ未入力時）
        while (_Sprites.Count != 10)
        {
            if (_Sprites.Count > 10)
            {
                _Sprites.RemoveAt(_Sprites.Count - 1);
            }
            else
            {
                _Sprites.Add(null);
            }
        }

        
        // 生成したコンポーネントを削除する（OnValidate メソッド内では Destroy を実行できないため処理を移譲した）
        EditorApplication.delayCall += () =>
        {
            // シーン再生から戻ったときに null になる場合があるため、ガード節が必要
            if (this == null) return;

            _Components.Where(component => component != null)
                       .ToList()
                       .ForEach(component => DestroyImmediate(component.gameObject));
            _Components.Clear();

            /*
            // 正しく動作していないため、停止させた
            if (_Components.Count() <= 0)
            {
                SetText(_Text, true);
            }
            */
        };
        
    }
    
#endif
    #endregion

    #region Public Methods

    /// <summary>
    /// テキストのカラーを変更します。
    /// </summary>
    /// <param name="color">カラー。</param>
    public void ChangeColor(Color color)
    {
        _Color = color;

        UpdateSprites();
    }

    /// <summary>
    /// テキストの表示レイアウトを変更します。
    /// </summary>
    /// <param name="layoutType">表示レイアウト。</param>
    public void ChangeLayout(LayoutType layoutType)
    {
        _LayoutType = layoutType;

        UpdateLayouts();
    }

    /// <summary>
    /// テキストの文字と文字の間隔を調整します。
    /// </summary>
    /// <param name="span">文字の間隔。</param>
    public void ChangeSpan(float span)
    {
        _Span = span;

        UpdateLayouts();
    }

    /// <summary>
    /// 表示しているテキストをクリアします。
    /// </summary>
    public void ClearText()
    {
        _Components.Where(component => component != null)
                                       .ToList()
                                       .ForEach(component => DestroyImmediate(component.gameObject));
        _Components.Clear();
    }

    /// <summary>
    /// 表示するテキストを設定します。
    /// </summary>
    /// <param name="value">表示する値。</param>
    public void SetText(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException($"テキストの値は 0 以上を設定しなければなりません。設定値 = {value}。");
        }

        SetText(value.ToString());
    }

    /// <summary>
    /// 表示するテキストを設定します。
    /// <para>
    /// 表示するフォーマットは０詰めなどの数字にだけ対応しています。（カンマなどは対応していない）
    /// </para>
    /// </summary>
    /// <param name="value">表示する値。</param>
    /// <param name="format">テキストフォーマット。</param>
    public void SetText(int value, string format)
    {
        SetText(value.ToString(format));
    }

    /// <summary>
    /// 表示するテキストを設定します。
    /// </summary>
    /// <param name="text">表示する値。</param>
    /// <param name="isForcibly">必ず更新するかどうかを決めるフラグ。</param>
    public void SetText(string text, bool isForcibly = false)
    {
        // テキストが同じ、強制変更のフラグが無効のときは、処理を終了します
        if (!isForcibly && _Text == text)
        {
            return;
        }

        // 表示テキストを更新します
        _Text = text;

        while (_Components.Count != text.Length)
        {
            if (_Components.Count > text.Length)
            {
                var component = _Components[0];

                _Components.Remove(component);

                if (Application.isPlaying)
                {
                    Destroy(component.gameObject);
                }
                else
                {
                    DestroyImmediate(component.gameObject);
                }
            }
            else
            {
                var child = new GameObject(_Components.Count.ToString());

                child.transform.SetParent(transform, false);

                var newRenderer = child.AddComponent<T>();

                _Components.Add(newRenderer);
            }
        }

        // すべてのコンポーネントを更新します
        UpdateComponents();
    }

    #endregion

    protected abstract void InitializeComponent(T component);
    protected abstract void UpdateComponent(T component, Sprite sprite, Color color);

    protected void InitializeComponents()
    {
        _Components.ForEach(component => InitializeComponent(component));
    }

    private void UpdateComponents()
    {
        UpdateSprites();
        UpdateLayouts();

        if (_AnimationController != null)
        {
            AttachAnimation();
        }
    }

    private void UpdateSprites()
    {
        for (var i = 0; i < _Components.Count; i++)
        {
            var no = int.Parse(_Text[i].ToString());

            UpdateComponent(_Components[i], _Sprites[no], _Color);
        }
    }

    private void UpdateLayouts()
    {
        var textLenght = _Text.Length;

        for (var i = 0; i < _Components.Count; i++)
        {
            var position = Vector3.zero;
            var width = _Components[i].GetComponent<RectTransform>()?.sizeDelta.x ?? 0;

            switch (_LayoutType)
            {
                case LayoutType.Center:
                    position.x = (i - (textLenght - 1) / 2.0F) * width * _Span;
                    break;
                case LayoutType.Left:
                    position.x = i * width * _Span;
                    break;
                case LayoutType.Right:
                    position.x = -(textLenght - 1 - i) * width * _Span;
                    break;
            }

            _Components[i].transform.localPosition = position;
        }
    }

    private void AttachAnimation()
    {
        for (var i = 0; i < _Components.Count; i++)
        {
            StartCoroutine(this.DelayAction(i * _AnimationDelaySeconds, (int no, int length) =>
            {
                var animation = _Components[no].gameObject.AddComponent<SpriteAnimation>();
                var animator = _Components[no].gameObject.AddComponent<Animator>();

                animation.Initialize(no + 1, _Components.Count());
                animator.runtimeAnimatorController = _AnimationController;
                animator.speed = _AnimationSpeed;
                animator.enabled = true;

                // 末尾のデータ
                if (no + 1 == length)
                {
                    animation.Completed += (sender, args) =>
                    {
                        StartCoroutine(this.DelayAction(_DestoryDelaySeconds, () =>
                        {
                            ClearText();
                            Destroy(transform.gameObject);
                        }));
                    };
                }

            }, i, _Components.Count));
        }
    }

}
